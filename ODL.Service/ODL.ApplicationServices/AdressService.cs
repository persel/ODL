using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Person;
using ODL.ApplicationServices.Validation;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;

namespace ODL.ApplicationServices
{
    public class AdressService : IAdressService
    {
        private readonly IPersonRepository personRepository;
        private readonly IAdressRepository adressRepository;
        private readonly ILogger<OrganisationService> logger;

        public AdressService(IPersonRepository personRepository, IAdressRepository adressRepository, ILogger<OrganisationService> logger)
        {
            this.personRepository = personRepository;
            this.adressRepository = adressRepository;
            this.logger = logger;
        }

        public Adress GetByAdressId(int adressId)
        {
           return adressRepository.GetByAdressId(adressId);
        }

        public void SparaPersonAdress(PersonAdressInputDTO personAdressInput)
        {
            var valideringsfel = new PersonAdressInputValidator().Validate(personAdressInput);
            new AdressInputValidator().Validate(personAdressInput, valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ApplicationException($"Valideringsfel inträffade vid validering av adress för person med Id: {personAdressInput.Personnummer}.");
            }

            //Hämta PersonId
            var person = personRepository.GetByPersonnummer(personAdressInput.Personnummer) ?? new Person();

            //Om personen inte finns ska man ej kunna spara adressen
            if (person.IsNew)
            {
                logger.LogError("Kan ej spara adress för person med personummer: " + personAdressInput.Personnummer + ". Personen sakans i databasen.");
                throw new ApplicationException($"Kan ej spara adress för person med personummer: {personAdressInput.Personnummer}. Personen sakans i databasen.");
            }

            //Hämta personens adressIdn
            var allaAdressIdn = personRepository.GetAllaAdressIdnPerPerson(personAdressInput.Personnummer);

            //Om inga adresser finns för personen, spara ny. Annars hämta befintliga adresser för ev uppdatering.
            var adress = new Adress();

            //Jämför input med befintligt data
            if (!string.IsNullOrEmpty(personAdressInput.GatuadressInput.AdressRad1))
                //kolla om ny eller befintlig gatuadress
            if (!string.IsNullOrEmpty(personAdressInput.MailInput.MailAdress))
                //kolla om ny eller befintlig epostadress
            if (!string.IsNullOrEmpty(personAdressInput.TelefonInput.Telefonnummer))
                        //kolla om nytt eller befintligt telfonnummer


            foreach (var adrId in allaAdressIdn)
            {
                adress = adressRepository.GetByAdressId(adrId);
            }

            

            if (adress.IsNew)
                adressRepository.Add(adress);
            else
                adressRepository.Update();
        }


    

        public void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdress)
        {
            throw new NotImplementedException();
        }
    }
}
