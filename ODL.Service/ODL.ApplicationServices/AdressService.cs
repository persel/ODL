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
    public class AdressService : IAdressService
    {

        private readonly IAdressRepository adressRepository;
        private readonly ILogger<OrganisationService> logger;

        public AdressService(IAdressRepository adressRepository, ILogger<OrganisationService> logger)
        {
            this.adressRepository = adressRepository;
            this.logger = logger;
        }

        public void SparaPersonAdress(PersonAdressInputDTO personAdress)
        {
            var valideringsfel = new PersonAdressInputValidator().Validate(personAdress);
            new AdressInputValidator().Validate(personAdress,valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ApplicationException($"Valideringsfel inträffade vid validering av adress för person med Id: {personAdress.Personnummer}.");
            }


        }

        public void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdress)
        {
            throw new NotImplementedException();
        }
    }
}
