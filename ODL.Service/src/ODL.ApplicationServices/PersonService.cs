using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.ApplicationServices.Queries;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;
using ODL.DomainModel;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IOrganisationRepository organisationRepository;
        private readonly IAvtalRepository avtalRepository;
        private readonly IContext context;
        private readonly ILogger<PersonService> logger;

        public PersonService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAvtalRepository avtalRepository, IContext context, ILogger<PersonService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.avtalRepository = avtalRepository;
            this.context = context;
            this.logger = logger;
    }

        public void SparaPerson(PersonInputDTO personInputDTO)
        {
            var valideringsfel = new PersonInputValidator().Validate(personInputDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message); 
                throw new BusinessLogicException($"Valideringsfel inträffade vid validering av Person med Id: {personInputDTO.Personnummer}.");
            }

            var person = personRepository.GetByPersonnummer(personInputDTO.Personnummer) ?? new Person();

            person.Personnummer = personInputDTO.Personnummer;
            person.Efternamn = personInputDTO.Efternamn;
            person.Fornamn = personInputDTO.Fornamn;
            person.Mellannamn = personInputDTO.Mellannamn;
            person.KallsystemId = personInputDTO.SystemId;
            person.Metadata = personInputDTO.GetMetadata();
            
            if (person.IsNew)
                personRepository.Add(person);
            else
                personRepository.Update();

        }

        public PersonDTO GetPersonByPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);
            return new PersonDTO
            {
                Id = person.Id,
                Namn = $" {person.Fornamn} {person.Efternamn}",
                Personnummer = person.Personnummer
            };
        }

        
        public IEnumerable<PersonPerResultatenhetDTO> GetPersonerPerResultatenhet(string kstNr)
        {
            return new PersonerPerResultatenhetQuery(context).Execute(kstNr);
        }


        public IEnumerable<ResultatenhetansvarigDTO> GetResultatenhetsansvarigaMedLeveransadress()
        {
            return new ResultatenhetsansvarigaMedLeveransadressQuery(context).Execute();
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

            if (avtal.IsNew)
            {
                var person = personRepository.GetByPersonnummer(avtalDTO.Personnummer);
                if (person == null)
                {
                    throw new ArgumentException($"Avtalet kunde inte sparas - angiven person med personnummer '{avtalDTO.Personnummer}' saknas i ODL.");
                }
                if (!string.IsNullOrEmpty(avtalDTO.AnstalldPersonnummer))
                    avtal.LaggTillAnstalld(person);
                else
                    avtal.LaggTillKonsult(person);
            }

            var kstnrList = avtalDTO.Kostnadsstallen.Select(kst => kst.KostnadsstalleNr);

            //var organisationer = organisationRepository.GetOrganisationerByKstnr(kstnrList);

            foreach (string kstNr in kstnrList)
            {
                var organisation = organisationRepository.GetOrganisationByKstnr(kstNr);
                if (organisation == null)
                {
                    throw new ArgumentException($"Avtalet kunde inte sparas - angiven resultatenhet med kostnadsställe '{kstNr}' saknas i ODL.");
                }

                var orgAvtal = avtal.OrganisationAvtal.SingleOrDefault(orgAvt => orgAvt.OrganisationId == organisation.Id) ?? new OrganisationAvtal();
                var kstDTO = avtalDTO.Kostnadsstallen.Single(kst => kst.KostnadsstalleNr == organisation.Resultatenhet.KstNr);
                orgAvtal.OrganisationId = organisation.Id; // Bara relevant om den är ny...
                orgAvtal.Huvudkostnadsstalle = kstDTO.Huvudkostnadsstalle;
                orgAvtal.ProcentuellFordelning = kstDTO.ProcentuellFordelning;

                if (orgAvtal.IsNew)
                    avtal.LaggTillOrganisationAvtal(orgAvtal);
            }
            
            if (avtal.IsNew)
                    avtalRepository.Add(avtal);
                else
                    avtalRepository.Update();
            }
    }
}
