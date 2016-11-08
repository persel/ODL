using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.DataAccess;
using ODL.DataAccess.Models; // TODO: Beroende till DataAccess bör ev. tas bort, lägg persistence model i eget projekt och referera till detta istället? (motsv. Domain Model)

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class AnstalldController : Controller
    {
        private readonly IPersonService _personService;

        public AnstalldController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/anstalld
        //[HttpGet]
        //public IEnumerable<AnstalldDTO> Get()
        //{

        //    var anstallda =
        //        _personService.GetAllAnstallda()
        //            .Select(anstalld => new AnstalldDTO {Id = anstalld.Id, Alias = anstalld.Alias});

        //    return anstallda;
        //}

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
