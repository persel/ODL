using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.ApplicationServices.Queries;
using ODL.DataAccess.Repositories;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess;
using ODL.DomainModel;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IOrganisationRepository organisationRepository;
        private readonly IPersonRepository personRepository;
        private readonly IAdressRepository adressRepository;
        private readonly IAdressVariantRepository adressVariantRepository;
        private readonly IContext context;
        private readonly ILogger<OrganisationService> logger;

        public OrganisationService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAdressRepository adressRepository, IAdressVariantRepository adressVariantRepository, IContext context, ILogger<OrganisationService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.adressRepository = adressRepository;
            this.adressVariantRepository = adressVariantRepository;
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheterForPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

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
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public ResultatenhetDTO GetResultatenhetForKstNr(string kostnadsstalleNr)
        {
            var organisation = organisationRepository.GetOrganisationByKstnr(kostnadsstalleNr);
            var resultatenhet = organisation.Resultatenhet;
            
            var variant = adressVariantRepository.GetVariantByVariantName("Leveransadress"); // TODO : Använd Value Object för AdressVariant!

            var leveransAdress = adressRepository.GetAdressPerOrganisationsIdAndVariantId(organisation.Id, variant.Id)?.Gatuadress;

            var resultatenhetDTO = 
                new ResultatenhetDTO
                {
                    Id = resultatenhet.OrganisationId,
                    KostnadsstalleNr = resultatenhet.KstNr,
                    Typ = resultatenhet.Typ,
                    Namn = organisation.Namn,
                    LeveransAdress = leveransAdress?.AdressRad1,
                    Postadress = leveransAdress?.Stad,
                    Postnummer = leveransAdress?.Postnummer
                };

            return resultatenhetDTO;
        }

        public void SparaResultatenhet(ResultatenhetInputDTO resultatenhet)
        {
            var valideringsfel = new ResultatenhetInputValidator().Validate(resultatenhet);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new BusinessLogicException($"Valideringsfel inträffade vid validering av resultatenhet med kostnadsställenummer: {resultatenhet.KostnadsstalleNr}.");
            }

            var organisation = organisationRepository.GetOrganisationByKstnr(resultatenhet.KostnadsstalleNr) ?? Organisation.SkapaNyResultatenhet();

            organisation.OrganisationsId = resultatenhet.OrganisationsId;
            organisation.Namn = resultatenhet.Namn;
            organisation.Metadata = resultatenhet.GetMetadata();

            var resultatenhetAttSpara = organisation.Resultatenhet;
            resultatenhetAttSpara.Typ = resultatenhet.Typ;
            resultatenhetAttSpara.KstNr = resultatenhet.KostnadsstalleNr;

            if (resultatenhetAttSpara.IsNew)
                organisationRepository.Add(organisation);
            else
                organisationRepository.Update();
        }


    }
}
