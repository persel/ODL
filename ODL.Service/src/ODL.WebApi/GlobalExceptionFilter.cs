using System;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
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
            var timeStamp = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            var exception = context.Exception;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ApplicationException)) // Visa felmeddelandet (skapat av oss - användarvänligt meddelande!)
            {
                clientMessage = " Server fel. LogId: " + timeStamp + " " + context.Exception.Message;
            }
            else
            {
                clientMessage = " Server fel. LogId: " + timeStamp + " se logfil."; 
                logger.LogError(timeStamp + " Ett fel hanterades i GlobalExceptionFilter: '{message}'", exception.ToString());
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = clientMessage;
           
            response.ContentType = "application/json";

            context.Result = new JsonResult(clientMessage);
        }
    }
}