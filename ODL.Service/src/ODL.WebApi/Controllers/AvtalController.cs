using Microsoft.AspNetCore.Mvc;
using ODL.ApplicationServices;
using ODL.ApplicationServices.DTOModel.Load;

namespace ODL.Service.Controllers
{
    [Route("api/[controller]")]
    public class AvtalController : Controller
    {
        private readonly IAvtalService _avtalService;

        public AvtalController(IAvtalService avtalService)
        {
            _avtalService = avtalService;
        }

        // POST api/avtal/spara/
        [HttpPost("spara")]
        public void SparaAvtal([FromBody]AvtalInputDTO avtal)
        {
            _avtalService.SparaAvtal(avtal);
        }
    }
}
