using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Person;
using ODL.ApplicationServices.Validation;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IResultatenhetRepository resultatenhetRepository;
        private readonly IOrganisationRepository organisationRepository;
        private readonly IPersonRepository personRepository;
        private readonly ILogger<OrganisationService> logger;

        public OrganisationService(IResultatenhetRepository resultatenhetRepository, IPersonRepository personRepository, IOrganisationRepository organisationRepository, ILogger<OrganisationService> logger)
        {
            this.resultatenhetRepository = resultatenhetRepository;
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.logger = logger;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

            var resultatenheter =  resultatenhetRepository.GetByAvtalIdn(person.AllaAvtalIdn());

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr,
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheter()
        {
            var resultatenheter = resultatenhetRepository.GetAll();

            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationFKId,
                    KostnadsstalleNr = enhet.KstNr,
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

            var resultatenhet = resultatenhetRepository.GetResultatenhetByKstnr(resEnhetInputDTO.KostnadsstalleNr) ?? new Resultatenhet();

            resultatenhet.Typ = resEnhetInputDTO.Typ;
            resultatenhet.KstNr = resEnhetInputDTO.KostnadsstalleNr;
            resultatenhet.Metadata = resEnhetInputDTO.GetMetadata();
            //TODO - Alle? Nytt kstnr, orgid?
            //resultatenhet.Organisation =
            resultatenhet.OrganisationFKId = 5;

            if (resultatenhet.IsNew)
                resultatenhetRepository.Add(resultatenhet);
            else
                resultatenhetRepository.Update();
        }

        public void SparaOrganisation(OrganisationInputDTO orgInputDTO)
        {
            var valideringsfel = new OrganisationInputValidator().Validate(orgInputDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ApplicationException($"Valideringsfel inträffade vid validering av organisation med organisationsid: {orgInputDTO.OrgId}.");
            }

            var organisation = organisationRepository.GetByOrgId(orgInputDTO.OrgId) ?? new Organisation();

            organisation.OrganisationsId = orgInputDTO.OrgId;
            organisation.Metadata = orgInputDTO.GetMetadata();
            organisation.Namn = orgInputDTO.Namn;
            //TODO - Resten 


            if (organisation.IsNew)
                organisationRepository.Add(organisation);
            else
                organisationRepository.Update();
        }
    }
}
