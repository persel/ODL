using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Query;
using Microsoft.AspNetCore.Authorization;
using ODL.InfrastructureServices;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Policy = "ValidUserName")]
    public class OrganisationController : Controller
    {
        private readonly IOrganisationService _organisationService;
        //private readonly IAnvandare _anvandare;

        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
          
        }

        // GET api/organisation/resultatenhet
        [HttpGet("resultatenhet/")] // TODO: Plural-namn?
        public IEnumerable<ResultatenhetDTO> Get()
        {
            //ToDO får se över det här... Mest i test syfte nu
            // I MinimumRequirementHandler finns grundläggande behörighets kontroll som alltid körs här blir det mest vilken data man kan se..
           
            //olika alternativ 
            //1. skapa en användare för att plocka ut alla värden ifrån måste i så fall köra new enligt nedan.
            // Man får en standars anv som man kan skicka överallt där man enkelt kommer åt alla värden
            var anvandare = new Anvandare(HttpContext.User);
            var t = anvandare.AnvandarNamn;

            //2. Denna är global behöver ej skapa en new anv men då måste man som nedan skriva lite mer samt veta typ?
            var t2 = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AnvandarNamn")?.Value;

            return _organisationService.GetResultatenheter();
        }

        // GET api/organisation/resultatenhet/1234
        [HttpGet("resultatenhet/{kstNr}")]
        public ResultatenhetDTO GetResultatenhet(string kstNr) // TODO: Set appropriate authorization on this method and/or pick personnummer from credentials/auth. ticket
        {
            return _organisationService.GetResultatenhetForKstNr(kstNr);
        }

        // GET api/organisation/resultatenheter
        [HttpGet("resultatenheter")]
        public IEnumerable<ResultatenhetDTO> GetResultatenheterForPersonnummer([FromQuery]string personnummer)
        {
            return _organisationService.GetResultatenheterForPersonnummer(personnummer);
        }

        // POST api/organisation/spara
        [HttpPost("spara")]
        public void SparaResultatenhet([FromBody]IList<ResultatenhetInputDTO> resultatenheter)
        {
            _organisationService.SparaResultatenheter(resultatenheter);
        }

    }
}
