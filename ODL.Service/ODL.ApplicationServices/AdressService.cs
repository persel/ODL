using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        private readonly IAdressVariantRepository adressVariantRepository;
        private readonly ILogger<AdressService> logger;

        public AdressService(IAdressRepository adressRepository, IPersonRepository personRepository, IAdressVariantRepository adressVariantRepository, ILogger<AdressService> logger)
        {
            this.personRepository = personRepository;
            this.adressRepository = adressRepository;
            this.adressVariantRepository = adressVariantRepository;
            this.logger = logger;
        }

        public Adress GetByAdressId(int adressId)
        {
           return adressRepository.GetByAdressId(adressId);
        }

        public void SparaPersonAdress(PersonAdressInputDTO personAdressInput)
        {
            var gatuadress = personAdressInput.GatuadressInput;
            var epostadress = personAdressInput.MailInput;
            var telefon = personAdressInput.TelefonInput;

            var valideringsfel = new PersonAdressInputValidator().Validate(personAdressInput);
            new AdressInputValidator().Validate(personAdressInput, valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ApplicationException($"Valideringsfel inträffade vid validering av adress för person med Id: {personAdressInput.Personnummer}.");
            }

            //Hämta PersonId
            var person = personRepository.GetByPersonnummer(personAdressInput.Personnummer);

            //Hämta variant
            var variant = adressVariantRepository.GetVariantByVariantName(personAdressInput.AdressVariant);

            //Om personen inte finns ska man ej kunna spara adressen
            if (person == null)
            {
                logger.LogError("Kan ej spara adress för person med personummer: " + personAdressInput.Personnummer + ". Personen sakans i databasen.");
                throw new ApplicationException($"Kan ej spara adress för person med personummer: {personAdressInput.Personnummer}. Personen sakans i databasen.");
            }

            //Om inga adresser finns för personen, spara ny. Annars hämta befintliga adresser för ev uppdatering.

            var adress = adressRepository.GetAdressPerPersonIdAndVariantId(person.Id, variant.Id);

            //Jämför input med befintligt data
            if (gatuadress != null)
            {
                //kolla om ny eller befintlig gatuadress
            }
            else if (epostadress != null)
            {
                if(adress == null)
                    adress = Adress.NewEpostAdress(person);
                adress.Mail.MailAdress = personAdressInput.MailInput.MailAdress;
            }
           else if (telefon != null)
            {
                //kolla om nytt eller befintligt telefonnummer
            }

            adress.Metadata = personAdressInput.GetMetadata();

            if (adress.IsNew)
            {
                adress.SetVariant(variant);
                adressRepository.Add(adress);
            }
            else
                adressRepository.Update();

        }


    

        public void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdress)
        {
            throw new NotImplementedException();
        }
    }
}
