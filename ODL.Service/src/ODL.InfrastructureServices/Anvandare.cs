using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ODL.InfrastructureServices
{
    public class Anvandare : IAnvandare
    {
       
        public Anvandare(ClaimsPrincipal user)
        { 
            Namn = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            AnvandarNamn = user.Claims.FirstOrDefault(c => c.Type == "AnvandarNamn")?.Value;
            Email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var minaRolerString = user.Claims.FirstOrDefault(c => c.Type == "Roler")?.Value;
            if (minaRolerString != null) Roler = new List<string>(minaRolerString.Split(','));
            
            var minaRbacString = user.Claims.FirstOrDefault(c => c.Type == "Rbac")?.Value;
            if (minaRbacString != null) Rbac = new List<string>(minaRbacString.Split(','));
            
            Personnummer = user.Claims.FirstOrDefault(c => c.Type == "Personnummer")?.Value;
            Applikation = user.Claims.FirstOrDefault(c => c.Type == "Applikation")?.Value;
        }

        public string Personnummer { get; }

        public string AnvandarNamn { get; }

        public string Namn { get; }

        public string Email { get; }

        public IEnumerable<string> Roler { get; }

        public IEnumerable<string> Rbac { get; }

        public string Applikation { get; }

        public bool IsBehorig()
        {
            return true;
        }
    }
}
