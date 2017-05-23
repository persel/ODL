using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using Microsoft.AspNetCore.Authorization;
using ODL.InfrastructureServices;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ValidUserName")]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationService _organisationService;
        private readonly IBehorighet _behorighet;

        public OrganisationController(IOrganisationService organisationService, IBehorighet behorighet)
        {
            _organisationService = organisationService;
            _behorighet = behorighet;
        }

        // GET api/organisation/resultatenhet
        [HttpGet("resultatenhet/")] // TODO: Plural-namn?
        public IEnumerable<ResultatenhetDTO> Get()
        {
            //ToDO får se över det här... Mest i test syfte nu
            // I MinimumRequirementHandler finns grundläggande behörighets kontroll som alltid körs här blir det mest vilken data man kan se..
            //var headerAnvandare = new Behorighet(HttpContext.User.Identity);
            _behorighet.SetAnvandare(HttpContext.User.Identity);

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
