using System;
using System.Net;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ODL.Service
{
    public class GlobalExceptionFilter : IExceptionFilter//, IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(GlobalExceptionFilter));

        //public GlobalExceptionFilter(ILoggerFactory logger)
        //{
        //    if (logger == null)
        //    {
        //        throw new ArgumentNullException(nameof(logger));
        //    }

        //    this._logger = logger.CreateLogger("Global Exception Filter");
        //}

        public void OnException(ExceptionContext context)
        {

            var status = HttpStatusCode.InternalServerError;
            string message;

            var exception = context.Exception;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(ApplicationException)) // Visa felmeddelandet (skapat av oss - användarvänligt meddelande!)
            {
                message = context.Exception.ToString();
            }
            else
            {
                message = "Ett serverfel har inträffat."; // TODO: Lägg ev. till ett korrelationsid i loggen och i meddelandet!

                if (Log.IsErrorEnabled)
                    Log.Error(context.Exception);
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
            response.WriteAsync(err);


        }
    }
}