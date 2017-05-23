using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/person/personerperresultatenhet
        [HttpGet("personerperresultatenhet")]
        public IEnumerable<PersonPerResultatenhetDTO> GetPersonerPerResultatenhet([FromQuery]string kstNr)
        {
            return _personService.GetPersonerPerResultatenhet(kstNr);
        }

        // POST api/person/avtal/
        [HttpPost("avtal")]
        public void SparaAvtal([FromBody]AvtalInputDTO avtal)
        {
            _personService.SparaAvtal(avtal);
        }

        // POST api/person/
        [HttpPost("person")]
        public void SparaPerson([FromBody]PersonInputDTO person)
        {
            _personService.SparaPerson(person);
        }
    }
}
