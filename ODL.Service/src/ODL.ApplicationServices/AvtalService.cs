using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess.Repositories;
using ODL.DomainModel;
using ODL.DomainModel.Avtal;

namespace ODL.ApplicationServices
{
    public class AvtalService : IAvtalService
    {
        private readonly IPersonRepository personRepository;
        private readonly IOrganisationRepository organisationRepository;
        private readonly IAvtalRepository avtalRepository;
        private readonly ILogger<PersonService> logger;

        public AvtalService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAvtalRepository avtalRepository, ILogger<PersonService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.avtalRepository = avtalRepository;
            this.logger = logger;
        }
        

        public void SparaAvtal(AvtalInputDTO avtalDTO)
        {
            var valideringsfel = new AvtalInputValidator().Validate(avtalDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message); // Hmm, borde vi logga detta med Info? 
                throw new BusinessLogicException(
                    $"Valideringsfel inträffade vid validering av Avtal med Id: {avtalDTO.SystemId}.");
            }

            var avtal = avtalRepository.GetByKallsystemId(avtalDTO.SystemId) ?? new Avtal();

            avtal.KallsystemId = avtalDTO.SystemId;
            avtal.Avtalskod = avtalDTO.Avtalskod;
            avtal.Avtalstext = avtalDTO.Avtalstext;
            avtal.ArbetstidVecka = avtalDTO.ArbetstidVecka;
            avtal.Befkod = avtalDTO.Befkod;
            avtal.BefText = avtalDTO.BefText;
            avtal.Aktiv = avtalDTO.Aktiv;
            avtal.Ansvarig = avtalDTO.Ansvarig;
            avtal.Chef = avtalDTO.Chef;
            avtal.TjledigFran = avtalDTO.TjledigFran.TillDatum();
            avtal.TjledigTom = avtalDTO.TjledigTom.TillDatum();
            avtal.Fproc = avtalDTO.Fproc;
            avtal.DeltidFranvaro = avtalDTO.DeltidFranvaro;
            avtal.FranvaroProcent = avtalDTO.FranvaroProcent;
            avtal.SjukP = avtalDTO.SjukP;
            avtal.GrundArbtidVecka = avtalDTO.GrundArbtidVecka;
            avtal.Lon = avtalDTO.TimLon;
            avtal.LonDatum = avtalDTO.LonDatum.TillDatum();
            avtal.LoneTyp = avtalDTO.LoneTyp;
            avtal.LoneTillagg = avtalDTO.LoneTillagg;
            avtal.TimLon = avtalDTO.TimLon;
            avtal.Anstallningsdatum = avtalDTO.Anstallningsdatum.TillDatum();
            avtal.Avgangsdatum = avtalDTO.Avgangsdatum.TillDatum();
            avtal.Metadata = avtalDTO.GetMetadata();

            if (avtal.Ny)
            {
                var person = personRepository.GetByPersonnummer(avtalDTO.Personnummer);
                if (person == null)
                {
                    throw new ArgumentException($"Avtalet kunde inte sparas - angiven person med personnummer '{avtalDTO.Personnummer}' saknas i ODL.");
                }
                if (!string.IsNullOrEmpty(avtalDTO.AnstalldPersonnummer))
                    avtal.KopplaTillAnstalld(person);
                else
                    avtal.KopplaTillKonsult(person);
            }

            var kstnrList = avtalDTO.Kostnadsstallen.Select(kst => kst.KostnadsstalleNr);

            foreach (string kstNr in kstnrList)
            {
                var organisation = organisationRepository.GetOrganisationByKstnr(kstNr);

                if (organisation == null)
                    throw new ArgumentException($"Avtalet kunde inte sparas - angiven resultatenhet med kostnadsställe '{kstNr}' saknas i ODL.");
                

                var kstDTO = avtalDTO.Kostnadsstallen.Single(kst => kst.KostnadsstalleNr == organisation.Resultatenhet.KstNr);

                avtal.LaggTillOrganisation(organisation, kstDTO.Huvudkostnadsstalle, kstDTO.ProcentuellFordelning);
            }
            
            if (avtal.Ny)
                    avtalRepository.Add(avtal);
                else
                    avtalRepository.Update();
            }
    }
}
