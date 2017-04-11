using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess.Repositories;
using ODL.ApplicationServices.Validation;
using ODL.DomainModel;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class OrganisationService : IOrganisationService
    {

        private readonly IOrganisationRepository organisationRepository;
        private readonly IPersonRepository personRepository;
        private readonly IAvtalRepository avtalRepository;
        private readonly ILogger<OrganisationService> logger;

        public OrganisationService(IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAvtalRepository avtalRepository, ILogger<OrganisationService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.avtalRepository = avtalRepository;
            this.logger = logger;
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenhetByPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);

            var avtalIdn = avtalRepository.GetAvtalIdnByPersonId(person.Id);
            var resultatenheter = organisationRepository.GetByAvtalIdn(avtalIdn).Select(org => org.Resultatenhet);
            
            return resultatenheter.Select(enhet =>
                new ResultatenhetDTO
                {
                    Id = enhet.OrganisationId,
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
                    Id = enhet.OrganisationId,
                    KostnadsstalleNr = enhet.KstNr.ToString(),
                    Typ = enhet.Typ,
                    Namn = enhet.Organisation.Namn
                });
        }

        public IEnumerable<ResultatenhetDTO> GetResultatenheterByKstNr(List<string> kostnadsstalleNr)
        {
            
            var organisationer = organisationRepository.GetByKstNr(kostnadsstalleNr);
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

        public void SparaResultatenhet(ResultatenhetInputDTO resEnhetInputDTO)
        {
            var valideringsfel = new ResultatenhetInputValidator().Validate(resEnhetInputDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new BusinessLogicException($"Valideringsfel inträffade vid validering av resultatenhet med kostnadsställenummer: {resEnhetInputDTO.KostnadsstalleNr}.");
            }

            var organisation = organisationRepository.GetOrganisationByKstnr(resEnhetInputDTO.KostnadsstalleNr) ?? Organisation.SkapaNyResultatenhet();

            organisation.OrganisationsId = resEnhetInputDTO.OrganisationsId;
            organisation.Namn = resEnhetInputDTO.Namn;
            organisation.Metadata = resEnhetInputDTO.GetMetadata();

            var resultatenhet = organisation.Resultatenhet;
            resultatenhet.Typ = resEnhetInputDTO.Typ;
            resultatenhet.KstNr = resEnhetInputDTO.KostnadsstalleNr;

            if (resultatenhet.IsNew)
                organisationRepository.Add(organisation);
            else
                organisationRepository.Update();
        }


    }
}
