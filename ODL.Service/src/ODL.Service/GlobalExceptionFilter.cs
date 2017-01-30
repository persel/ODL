using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ODL.Service
{
    public class GlobalExceptionFilter : IExceptionFilter//, ActionFilterAttribute, IDisposable
    {
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }


        public void OnException(ExceptionContext context)
        {

            var status = HttpStatusCode.InternalServerError;
            string clientMessage;

            var exception = context.Exception;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ApplicationException)) // Visa felmeddelandet (skapat av oss - användarvänligt meddelande!)
            {
                clientMessage = context.Exception.Message;
            }
            else
            {
                clientMessage = "Ett serverfel har inträffat."; // TODO: Lägg ev. till ett korrelationsid (eller bara timestamp) i loggen och i meddelandet!

                logger.LogError("Ett fel hanterades i GlobalExceptionFilter: '{message}'", exception.ToString());
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";

            context.Result = new JsonResult(clientMessage);
        }
    }
}