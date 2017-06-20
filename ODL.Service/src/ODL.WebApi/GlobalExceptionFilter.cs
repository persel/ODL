using System;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ODL.DomainModel;
using System.Net;

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

            if (exceptionType == typeof(BusinessLogicException)) // Visa felmeddelandet (skapat av oss - användarvänligt meddelande!)
            {
                clientMessage = context.Exception.Message;
            }
            else
            {
                var timeStamp = DateTime.Now.Ticks;
                clientMessage = $"Ett serverfel har inträffat. LogId: {timeStamp}";

                // Vi använder serilog message templates: https://github.com/serilog/serilog/wiki/Writing-Log-Events
                logger.LogError("Ett fel hanterades i GlobalExceptionFilter (LogId: {LogId}): '{Message}'.\nStacktrace: {StackTrace}", timeStamp, exception.Message, exception.StackTrace);
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase =  WebUtility.HtmlEncode(clientMessage);
           
            response.ContentType = "application/json";

            context.Result = new JsonResult(clientMessage);
        }
    }
}