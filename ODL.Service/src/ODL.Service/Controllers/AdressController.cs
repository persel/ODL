using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;

        // GET api/adress
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/adress/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/adress
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

        // PUT api/adress/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/adress/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
