using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
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

        // GET api/person/resultatenhet/5
        [HttpGet("resultatenhet/{resultatenhetId}")]
        public IEnumerable<PersonDTO> GetPersonByResultatenhetId(int resultatenhetId) // TODO: Set appropriate authorization on this method and/or pick personnummer from credentials/auth. ticket
        {
            return _personService.GetByResultatenhetId(resultatenhetId);
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
