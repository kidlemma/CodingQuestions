using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestion.Common.Exception
{
    public class ApiException : System.Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        public ApiException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ApiException(HttpStatusCode httpStatusCode, string message, System.Exception exception) : base(message, exception)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
