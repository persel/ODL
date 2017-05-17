using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using Microsoft.AspNetCore.Authorization;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
   // [Authorize(Policy = "ValidUserName")]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationService _organisationService;

        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        // GET api/organisation/resultatenhet
        [HttpGet("resultatenhet/")] // TODO: Plural-namn?
        public IEnumerable<ResultatenhetDTO> Get()
        {
            return _organisationService.GetResultatenheter();
        }

        // GET api/organisation/resultatenhet/1234
        [HttpGet("resultatenhet/{kstNr}")]
        public ResultatenhetDTO GetResultatenhet(string kstNr) // TODO: Set appropriate authorization on this method and/or pick personnummer from credentials/auth. ticket
        {
            return _organisationService.GetResultatenhetForKstNr(kstNr);
        }

        // GET api/organisation/resultatenheter/personnummer/197501011405
        [HttpGet("resultatenheter/personnummer/{personnummer}")]
        public IEnumerable<ResultatenhetDTO> GetResultatenheterForPersonnummer(string personnummer)
        {
            return _organisationService.GetResultatenheterForPersonnummer(personnummer);
        }

        // POST api/resultatenhet/
        [HttpPost("resultatenhet")]
        public void SparaResultatenhet([FromBody]ResultatenhetInputDTO resultatenhet)
        {
            _organisationService.SparaResultatenhet(resultatenhet);
        }

    }
}
