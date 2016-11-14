using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.Models;

// TODO: Beroende till DataAccess bör ev. tas bort, lägg persistence model i eget projekt och referera till detta istället? (motsv. Domain Model)

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
        

        // GET api/anstalld/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/anstalld
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/anstalld/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/anstalld/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
