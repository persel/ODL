using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MoreLinq;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.ApplicationServices.Queries;
using ODL.DataAccess.Repositories;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess;
using ODL.DomainModel;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Common;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IOrganisationRepository organisationRepository;
        private readonly IPersonRepository personRepository;
        private readonly IAdressRepository adressRepository;
        private readonly IContext context;
        private readonly ILogger<OrganisationService> logger;

        public OrganisationService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAdressRepository adressRepository, IContext context, ILogger<OrganisationService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.adressRepository = adressRepository;
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheterForPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

            if (person == null) return new List<ResultatenhetDTO>();

            var query = new ResultatenhetPerPersonQuery(context);

            return query.Execute(person.Id);

        }
        public IEnumerable<ResultatenhetDTO> GetResultatenheter()
        {
            var organisationer = organisationRepository.GetAll();
            var resultatenheter = organisationer.Select(org => org.Resultatenhet);

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ.ToString(),
                    Namn = enhet.Organisation.Namn
                });
        }

        public ResultatenhetDTO GetResultatenhetForKstNr(string kostnadsstalleNr)
        {
            var organisation = organisationRepository.GetOrganisationByKstnr(kostnadsstalleNr);
            var resultatenhet = organisation.Resultatenhet;
            
            
            var leveransAdress = adressRepository.GetAdressPerOrganisationsIdAndAdressvariant(organisation.Id, Adressvariant.Leveransadress)?.Gatuadress;

            var resultatenhetDTO = 
                new ResultatenhetDTO
                {
                    Id = resultatenhet.OrganisationId,
                    KostnadsstalleNr = resultatenhet.KstNr,
                    Typ = resultatenhet.Typ.ToString(),
                    Namn = organisation.Namn,
                    LeveransAdress = leveransAdress?.AdressRad1,
                    Postadress = leveransAdress?.Stad,
                    Postnummer = leveransAdress?.Postnummer
                };

            return resultatenhetDTO;
        }

        public void SparaResultatenheter(IList<ResultatenhetInputDTO> resultatenheter)
        {

            foreach (var resultatenhet in resultatenheter)
            {
                var valideringsfel = new ResultatenhetInputValidator().Validate(resultatenhet);
                if (valideringsfel.Any())
                {
                    foreach (var fel in valideringsfel)
                        logger.LogError(fel.Message);
                    throw new BusinessLogicException($@"Valideringsfel inträffade vid validering av resultatenhet med kostnadsställenummer: {resultatenhet.KostnadsstalleNr}. 
                                                     Följande kostnadsställen sparades ej: {string.Join("", "", resultatenheter.Select( re => re.KostnadsstalleNr))}");
                }
                var organisation = organisationRepository.GetOrganisationByKstnr(resultatenhet.KostnadsstalleNr) ?? Organisation.SkapaNyResultatenhet(resultatenhet.KostnadsstalleNr, resultatenhet.Typ.TillEnum<Kostnadsstalletyp>(), resultatenhet.OrganisationsId, resultatenhet.Namn, resultatenhet.GetMetadata());

                if (organisation.Ny)
                {
                    organisationRepository.Add(organisation);
                }
                else
                {
                    organisation.BytNamn(resultatenhet.Namn, resultatenhet.GetMetadata());
                    organisationRepository.Update();
                }
            }
        }
    }
}
