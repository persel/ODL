using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DataAccess.Repositories;
using ODL.ApplicationServices.Validation;
using ODL.DomainModel;
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices
{
    public class AdressService : IAdressService
    {
        private readonly IPersonRepository personRepository;
        private readonly IOrganisationRepository organisationRepository;
        private readonly IAdressRepository adressRepository;
        private readonly ILogger<AdressService> logger;

        public AdressService(IAdressRepository adressRepository, IPersonRepository personRepository, IOrganisationRepository organisationRepository, ILogger<AdressService> logger)
        {
            this.personRepository = personRepository;
            this.organisationRepository = organisationRepository;
            this.adressRepository = adressRepository;
            this.logger = logger;
        }

        public Adress GetByAdressId(int adressId)
        {
           return adressRepository.GetByAdressId(adressId);
        }

        public IEnumerable<AdressDTO> GetAdresserPerKostnadsstalleNr(string kstNr)
        {
            var organisation = organisationRepository.GetOrganisationByKstnr(kstNr);
            var adresser = adressRepository.GetAdresserPerOrganisationsId(organisation.Id);

            return adresser.Select(adress => new AdressDTO
            {
                Id = adress.Id,
                Gatuadress = GatuadressDTO.FromGatuadress(adress.Gatuadress),
                Epost = EpostDTO.FromEpost(adress.Epost),
                Telefon = TelefonDTO.FromTelefon(adress.Telefon)
            });
        }

        public IEnumerable<AdressDTO> GetAdresserPerPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);
            var adresser =  adressRepository.GetAdresserPerPersonId(person.Id);

            return adresser.Select(adress =>
                 new AdressDTO
                 {
                     Id = adress.Id,
                     Gatuadress = GatuadressDTO.FromGatuadress(adress.Gatuadress),
                     Epost = EpostDTO.FromEpost(adress.Epost),
                     Telefon = TelefonDTO.FromTelefon(adress.Telefon)
                 });
        }

        public void SparaPersonAdress(PersonAdressInputDTO personAdressInput)
        {

            var gatuadress = personAdressInput.GatuadressInput;
            var epostadress = personAdressInput.EpostInput;
            var telefon = personAdressInput.TelefonInput;
            var metadata = personAdressInput.GetMetadata();

            var valideringsfel = new PersonAdressInputValidator().Validate(personAdressInput);
            new AdressInputValidator().Validate(personAdressInput, valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new BusinessLogicException($"Valideringsfel inträffade vid validering av adress för person med Id: {personAdressInput.Personnummer}.");
            }

            var person = personRepository.GetByPersonnummer(personAdressInput.Personnummer);
            
            if (person == null)
                throw new ArgumentException($"Kan ej spara adress för person med personummer: {personAdressInput.Personnummer}. Personen saknas i databasen.");

            
            var variant = (Adressvariant)Enum.Parse(typeof(Adressvariant), personAdressInput.Adressvariant);

            if (variant == null)
                throw new ArgumentException($"Hittade ej Adressvarianten med namn: '{personAdressInput.Adressvariant}' i databasen.");
            

            var adress = adressRepository.GetAdressPerPersonIdAndAdressvariant(person.Id, variant);
            var nyAdress = adress == null;

            if (gatuadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, variant, metadata, person);
                else
                    adress.BytGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, metadata);
            }
            else if (epostadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyEpostAdress(epostadress.EpostAdress, variant, metadata, person);
                else
                    adress.BytEpostAdress(epostadress.EpostAdress, metadata);
            }
            else if (telefon != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyTelefonAdress(telefon.Telefonnummer, variant, metadata, person);
                else
                    adress.BytTelefonnummer(telefon.Telefonnummer, metadata);
            }
            
            if (adress.Ny)
                adressRepository.Add(adress);
            else
                adressRepository.Update();
        }

        public void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdressInput)
        {
            if (organisationAdressInput == null) throw new ArgumentException("organisationAdressInput är null, felaktig indata ");

            var gatuadress = organisationAdressInput.GatuadressInput;
            var epostadress = organisationAdressInput.EpostInput;
            var telefon = organisationAdressInput.TelefonInput;
            var metadata = organisationAdressInput.GetMetadata();

            var valideringsfel = new OrganisationAdressInputValidator().Validate(organisationAdressInput);
            new AdressInputValidator().Validate(organisationAdressInput, valideringsfel);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new ArgumentException($"Valideringsfel inträffade vid validering av adress för organisation med Id: {organisationAdressInput.KostnadsstalleNr}.");
            }
            
            var organisation = organisationRepository.GetOrganisationByKstnr(organisationAdressInput.KostnadsstalleNr);

            var variant = (Adressvariant)Enum.Parse(typeof(Adressvariant), organisationAdressInput.Adressvariant);
            
            if (organisation == null)
                throw new ArgumentException($"Kan ej spara adress för organisation med kostnadsställenummer: {organisationAdressInput.KostnadsstalleNr}. Organisationen saknas i databasen.");
            
            var adress = adressRepository.GetAdressPerOrganisationsIdAndAdressvariant(organisation.Id, variant);
            var nyAdress = adress == null;

            if (gatuadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, variant, metadata, organisation);
                else
                    adress.BytGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, metadata);
            }
            else if (epostadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyEpostAdress(epostadress.EpostAdress, variant, metadata, organisation);
                else
                    adress.BytEpostAdress(epostadress.EpostAdress, metadata);
            }
            else if (telefon != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyTelefonAdress(telefon.Telefonnummer, variant, metadata, organisation);
                else
                    adress.BytTelefonnummer(telefon.Telefonnummer, metadata);
            }
            
            if (adress.Ny)
                adressRepository.Add(adress);
            else
                adressRepository.Update();
        }
    }
}
