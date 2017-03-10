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
        private readonly IOrganisationRepository organisationRepository;
        private readonly IAdressRepository adressRepository;
        private readonly IAdressVariantRepository adressVariantRepository;
        private readonly ILogger<AdressService> logger;

        public AdressService(IAdressRepository adressRepository, IPersonRepository personRepository, IOrganisationRepository organisationRepository, IAdressVariantRepository adressVariantRepository, ILogger<AdressService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.adressRepository = adressRepository;
            this.adressVariantRepository = adressVariantRepository;
            this.logger = logger;
        }

        public Adress GetByAdressId(int adressId)
        {
           return adressRepository.GetByAdressId(adressId);
        }

        public IEnumerable<AdressDTO> GetAdresserPerKostnadsstalleNr(int kstnr)
        {
            var organisation = organisationRepository.GetOrganisationByKstnr(kstnr);
            var adresser = adressRepository.GetAdresserPerOrganisationsId(organisation.Id);

            return adresser.Select(enhet => new AdressDTO()
            {
                Id = enhet.AdressVariantFKId,
                GatuAdress = GatuAdressDTO.FromGatuadress(enhet.GatuAdress),
                Mail = MailDTO.FromMail(enhet.Mail),
                Telefon = TelefonDTO.Fromtelefon(enhet.Telefon)
            });
        }

        public IEnumerable<AdressDTO> GetAdresserPerPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);
            var adresser =  adressRepository.GetAdresserPerPersonId(person.Id);

            return adresser.Select(enhet =>
                 new AdressDTO()
                 {
                     Id = enhet.AdressVariantFKId,
                     GatuAdress = GatuAdressDTO.FromGatuadress(enhet.GatuAdress),
                     Mail = MailDTO.FromMail(enhet.Mail),
                     Telefon = TelefonDTO.Fromtelefon(enhet.Telefon)
                 });
        }

        public void SparaPersonAdress(PersonAdressInputDTO personAdressInput)
        {
            if (personAdressInput == null) throw new ApplicationException("personAdressInput är null, felaktig indata ");

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

            //Hämta Person
            var person = personRepository.GetByPersonnummer(personAdressInput.Personnummer);
            

            //Om personen inte finns ska man ej kunna spara adressen
            if (person == null)
            {
                throw new ArgumentException($"Kan ej spara adress för person med personummer: {personAdressInput.Personnummer}. Personen saknas i databasen.");
            }

            //Hämta variant
            var variant = adressVariantRepository.GetVariantByVariantName(personAdressInput.AdressVariant);

            if (variant == null)
            {
                throw new ArgumentException($"Hittade ej Adressvarianten med namn: '{personAdressInput.AdressVariant}' i databasen.");
            }

            var adress = adressRepository.GetAdressPerPersonIdAndVariantId(person.Id, variant.Id);

            if (gatuadress != null)
            {
                if (adress == null)
                    adress = Adress.NewGatuAdress(person);
                adress.GatuAdress.AdressRad1 = personAdressInput.GatuadressInput.AdressRad1;
                adress.GatuAdress.AdressRad2 = personAdressInput.GatuadressInput.AdressRad2;
                adress.GatuAdress.AdressRad3 = personAdressInput.GatuadressInput.AdressRad3;
                adress.GatuAdress.AdressRad4 = personAdressInput.GatuadressInput.AdressRad4;
                adress.GatuAdress.AdressRad5 = personAdressInput.GatuadressInput.AdressRad5;
                adress.GatuAdress.Postnummer = personAdressInput.GatuadressInput.Postnummer;
                adress.GatuAdress.Stad = personAdressInput.GatuadressInput.Stad;
                adress.GatuAdress.Land = personAdressInput.GatuadressInput.Land;

            }
            else if (epostadress != null)
            {
                if (adress == null) adress = Adress.NewEpostAdress(person);
                adress.Mail.MailAdress = personAdressInput.MailInput.MailAdress;
            }
            else if (telefon != null)
            {
                if (adress == null) adress = Adress.NewTelefonAdress(person);
                adress.Telefon.Telefonnummer = personAdressInput.TelefonInput.Telefonnummer;
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


    

        public void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdressInput)
        {
            if (organisationAdressInput == null) throw new ArgumentException("organisationAdressInput är null, felaktig indata ");

            var gatuadress = organisationAdressInput.GatuadressInput;
            var epostadress = organisationAdressInput.MailInput;
            var telefon = organisationAdressInput.TelefonInput;

            var valideringsfel = new OrganisationAdressInputValidator().Validate(organisationAdressInput);
            new AdressInputValidator().Validate(organisationAdressInput, valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ArgumentException($"Valideringsfel inträffade vid validering av adress för organisation med Id: {organisationAdressInput.KostnadsstalleNr}.");
            }

            
            var organisation = organisationRepository.GetOrganisationByKstnr(organisationAdressInput.KostnadsstalleNr);

           
            var variant = adressVariantRepository.GetVariantByVariantName(organisationAdressInput.AdressVariant);

            
            if (organisation == null)
            {
                throw new ArgumentException($"Kan ej spara adress för organisation med kostnadsställenummer: {organisationAdressInput.KostnadsstalleNr}. Organisationen saknas i databasen.");
            }

            //ToDO bugg here kan lägga till flera smäller när det blir 2 lika...
            var adress = adressRepository.GetAdressPerOrganisationsIdAndVariantId(organisation.Id, variant.Id);
            //ToDO titta på det verkar vara det enda som den från att skapa flera lika nya adresser?? adress.IsNew funkar ej..
            var adressList = adressRepository.GetAdressPerOrganisationsIdAndVariantIdList(organisation.Id, variant.Id);
           
            
            if (gatuadress != null)
            {
                if (adress == null) adress = Adress.NewGatuAdress(organisation);
                

                adress.GatuAdress.AdressRad1 = organisationAdressInput.GatuadressInput.AdressRad1;
                adress.GatuAdress.AdressRad2 = organisationAdressInput.GatuadressInput.AdressRad2;
                adress.GatuAdress.AdressRad3 = organisationAdressInput.GatuadressInput.AdressRad3;
                adress.GatuAdress.AdressRad4 = organisationAdressInput.GatuadressInput.AdressRad4;
                adress.GatuAdress.AdressRad5 = organisationAdressInput.GatuadressInput.AdressRad5;
                adress.GatuAdress.Postnummer = organisationAdressInput.GatuadressInput.Postnummer;
                adress.GatuAdress.Stad = organisationAdressInput.GatuadressInput.Stad;
                adress.GatuAdress.Land = organisationAdressInput.GatuadressInput.Land;

            }
            else if (epostadress != null)
            {
                if (adress == null)
                    adress = Adress.NewEpostAdress(organisation);
                adress.Mail.MailAdress = organisationAdressInput.MailInput.MailAdress;
            }
            else if (telefon != null)
            {
                if (adress == null)
                    adress = Adress.NewTelefonAdress(organisation);
                adress.Telefon.Telefonnummer = organisationAdressInput.TelefonInput.Telefonnummer;
            }

            adress.Metadata = organisationAdressInput.GetMetadata();

            if (adressList == null)//adress.IsNew)
            {
                adress.SetVariant(variant);
                adressRepository.Add(adress);
            }
            else
                adressRepository.Update();
        }
    }
}
