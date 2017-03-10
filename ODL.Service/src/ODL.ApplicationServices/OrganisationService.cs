using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Person;
using ODL.ApplicationServices.Validation;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IOrganisationRepository organisationRepository;
        private readonly IPersonRepository personRepository;
        private readonly ILogger<OrganisationService> logger;

        public OrganisationService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, ILogger<OrganisationService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.logger = logger;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

            var organisationer = organisationRepository.GetByAvtalIdn(person.AllaAvtalIdn());
            var resultatenheter = organisationer.Select(org => org.Resultatenhet);

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }


        public IEnumerable<ResultatenhetDTO> GetResultatenhetWhereAnsvarig(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

            var organisationer = organisationRepository.GetWhereAnsvarigByAvtalIdn(person.AllaAvtalIdn());
            var resultatenheter = organisationer.Select(org => org.Resultatenhet);

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheter()
        {
            var organisationer = organisationRepository.GetAll();
            var resultatenheter = organisationer.Select(org => org.Resultatenhet);

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheterByKstNr(List<int> kostnadsstalleNr)
        {
            var organisationer = organisationRepository.GetByKstNr(kostnadsstalleNr);
            var resultatenheter = organisationer.Select(org => org.Resultatenhet);

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public void SparaResultatenhet(ResultatenhetInputDTO resEnhetInputDTO)
        {
            var valideringsfel = new ResultatenhetInputValidator().Validate(resEnhetInputDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ApplicationException($"Valideringsfel inträffade vid validering av resultatenhet med kostnadsställenummer: {resEnhetInputDTO.KostnadsstalleNr}.");
            }

            //var organisation = organisationRepository.GetOrganisationByKstnr(resEnhetInputDTO.KostnadsstalleNr) ?? new Organisation();
            var organisation = organisationRepository.GetOrganisationByKstnr(resEnhetInputDTO.KostnadsstalleNr) ?? Organisation.SkapaNyResultatenhet();

            organisation.OrganisationsId = resEnhetInputDTO.OrganisationsId;
            organisation.Namn = resEnhetInputDTO.Namn;
            organisation.Metadata = resEnhetInputDTO.GetMetadata();

            var resultatenhet = organisation.Resultatenhet;
            resultatenhet.Typ = resEnhetInputDTO.Typ;
            resultatenhet.KstNr = resEnhetInputDTO.KostnadsstalleNr;
            resultatenhet.Metadata = resEnhetInputDTO.GetMetadata();

            if (resultatenhet.IsNew)
                organisationRepository.Add(organisation);
            else
                organisationRepository.Update();
        }


    }
}
