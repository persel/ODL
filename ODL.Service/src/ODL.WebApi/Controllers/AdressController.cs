using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DomainModel.Adress;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        // GET api/adress/
        [HttpGet("/{adressId}")]
        public Adress GetAdressByAdressId(int adressId)
        {
            return _adressService.GetByAdressId(adressId);
        }

        [HttpGet("personnummer/{personnummer}")]
        public IEnumerable<AdressDTO> GetAdresserPerPersonnummer(string personnummer)
        {
            return _adressService.GetAdresserPerPersonnummer(personnummer);
        }

        [HttpGet("kstnr/{kstnr}")]
        public IEnumerable<AdressDTO> GetAdresserPerKostnadsstalleNr(string kstNr)
        {
            return _adressService.GetAdresserPerKostnadsstalleNr(kstNr);
        }

        // POST api/adress/personadress
        [HttpPost("personadress")]
        public void SparaPersonAdress([FromBody]PersonAdressInputDTO personAdress)
        {
            _adressService.SparaPersonAdress(personAdress);
        }

        // POST api/adress/organisationadress
        [HttpPost("organisationadress")]
        public void SparaOrganisationAdress([FromBody]OrganisationAdressInputDTO organisationAdress)
        {
            _adressService.SparaOrganisationAdress(organisationAdress);
        }

    }
}
