using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/organisation/resultatenheter
        [HttpGet("resultatenheter/")]
        public IEnumerable<ResultatenhetDTO> GetResultatenhet([FromQuery]List<string> kostnadsstalleNr) // TODO: Set appropriate authorization on this method and/or pick personnummer from credentials/auth. ticket
        {
            return _organisationService.GetResultatenheterByKstNr(kostnadsstalleNr);
        }

        // GET api/organisation/resultatenhet/197501011405
        [HttpGet("resultatenhet/{personnummer}")]
        public IEnumerable<ResultatenhetDTO> GetResultatenhet(string personnummer)
        {
            return _organisationService.GetResultatenhetByPersonnummer(personnummer);
        }

        // POST api/resultatenhet/
        [HttpPost("resultatenhet")]
        public void SparaResultatenhet([FromBody]ResultatenhetInputDTO resultatenhet)
        {
            _organisationService.SparaResultatenhet(resultatenhet);
        }

    }
}
