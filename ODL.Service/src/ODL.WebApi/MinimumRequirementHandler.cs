using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KlientApplikationer.InfrastructureServices;
using Microsoft.AspNetCore.Authorization;

namespace ODL.WebApi
{
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

            var key = requirement.Key;
            var t = mvcContext.HttpContext.Request.Headers["IsValid"];

            var decryptAlias = EncrypDecrypt.Decrypt(
                cipherText: mvcContext.HttpContext.Request.Headers["IsValid"],
                passPhrase: key);

            if (decryptAlias != mvcContext.HttpContext.Request.Headers["AnvandarNamn"])
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
}