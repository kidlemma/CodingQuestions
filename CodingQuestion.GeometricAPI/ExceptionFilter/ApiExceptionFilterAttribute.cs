using CodingQuestion.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace CodingQuestion.GeometricAPI.ExceptionFilter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {

            if (context == null) return;

            if (context.Exception is ApiException)
            {
                var apiException = (ApiException)context.Exception;
                context.Response = context.Response = GetResponseMessage(context, apiException.HttpStatusCode);
            }
            else
            {
                context.Response = GetResponseMessage(context, HttpStatusCode.InternalServerError);
            }
        }


        protected HttpResponseMessage GetResponseMessage(HttpActionExecutedContext context, HttpStatusCode httpStatusCode,
            string content = "")
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                content = context.Exception.Message;
            }

            //TODO: Log exception

            return context.Response = new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent(content),
                ReasonPhrase = nameof(httpStatusCode),
                StatusCode = httpStatusCode
            };
        }
    }
}