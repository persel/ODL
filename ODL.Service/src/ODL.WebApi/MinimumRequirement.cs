using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;

namespace ODL.WebApi
{
    /**
     * Får skapa denna klass här eftersom core teknologi därför platsar den ej i infrastruktur projektet..
     * Här nedan får vi lägga in dom grundläggande kontrollerna 
     * */
    public class MinimumRequirementHandler : AuthorizationHandler<MinimumRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRequirement requirement)
        {
            
            var mvcContext = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;

            if (mvcContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //ToDO test purpuse Swagger
            //if (mvcContext.HttpContext.Request.GetUri().Host == "localhost") return Task.CompletedTask;

            //ToDo lägg in ett anrop för att kolla att det är en giltig alias? just nu kollar den bara att den existerar
            if (mvcContext.HttpContext.Request.Headers["AnvandarNamn"] == requirement.AnvandarNamn ||
                mvcContext.HttpContext.Request.Headers["AnvandarNamn"].Count <= 0)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim(ClaimTypes.Name, mvcContext.HttpContext.Request.Headers["Namn"]));
            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim(ClaimTypes.Role, "TestRoll"));
            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim(ClaimTypes.UserData, "testanvändarn"));
            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim(ClaimTypes.Email, mvcContext.HttpContext.Request.Headers["Email"]));
            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim("Applikation", mvcContext.HttpContext.Request.Headers["Applikation"]));
            context.User.Identities.FirstOrDefault()?.AddClaim(new Claim("AnvandarNamn", mvcContext.HttpContext.Request.Headers["AnvandarNamn"]));

            return Task.CompletedTask;
        }
    }


    public class MinimumRequirement : IAuthorizationRequirement
    {
        public MinimumRequirement(string anvandarNamn, string applikation, string namn)
        {
            AnvandarNamn = anvandarNamn;
            Applikation = applikation;
            Namn = namn;
        }

        public string AnvandarNamn { get; }

        public string Applikation { get; }

        public string Namn { get; }


    }
}
