using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class AdressController : Controller
    {
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
