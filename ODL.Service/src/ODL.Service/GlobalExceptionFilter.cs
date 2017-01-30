using System;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.Http;
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
            string message;

            var exception = context.Exception;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ApplicationException)) // Visa felmeddelandet (skapat av oss - användarvänligt meddelande!)
            {
                message = context.Exception.Message;
            }
            else
            {
                message = "Ett serverfel har inträffat."; // TODO: Lägg ev. till ett korrelationsid (eller bara timestamp) i loggen och i meddelandet!

                logger.LogError("Ett fel hanterades i GlobalExceptionFilter: '{message}'. Stacktrace: {stackTrace}", exception.Message, exception.StackTrace);
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
        
            context.Result = new JsonResult(message);
        }
    }
}