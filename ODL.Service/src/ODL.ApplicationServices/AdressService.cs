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
using ODL.DomainModel.Common;
using ODL.DomainModel.Person;

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

        public void SparaAdress(AdressInputDTO adressInput)
        {

            var gatuadress = adressInput.GatuadressInput;
            var epostadress = adressInput.EpostInput;
            var telefon = adressInput.TelefonInput;
            var metadata = adressInput.GetMetadata();

            var valideringsfel = new AdressInputValidator().Validate(adressInput);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message);
                throw new BusinessLogicException($"Valideringsfel inträffade för adress: {adressInput}.");
            }

            var adressInnehavare = adressInput.AvserPerson
                ? personRepository.GetByPersonnummer(adressInput.Personnummer)
                : organisationRepository.GetOrganisationByKstnr(adressInput.KostnadsstalleNr) as Adressinnehavare;


            if (adressInnehavare == null)
                throw new ArgumentException($"Kan ej spara adress. Innehavare saknas i databasen för adressen: {adressInput}.");
            
            var variant = adressInput.Adressvariant.TillEnum<Adressvariant>();
            
            var adress = adressRepository.GetAdressPerAdressInnehavareAndAdressvariant(adressInnehavare, variant);
            var nyAdress = adress == null;

            if (gatuadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, variant, metadata, adressInnehavare);
                else
                    adress.BytGatuadress(gatuadress.AdressRad1, gatuadress.Postnummer, gatuadress.Stad, gatuadress.Land, metadata);
            }
            else if (epostadress != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyEpostAdress(epostadress.EpostAdress, variant, metadata, adressInnehavare);
                else
                    adress.BytEpostAdress(epostadress.EpostAdress, metadata);
            }
            else if (telefon != null)
            {
                if (nyAdress)
                    adress = Adress.SkapaNyTelefonAdress(telefon.Telefonnummer, variant, metadata, adressInnehavare);
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
