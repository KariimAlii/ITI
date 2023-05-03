using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.APIs
{
    public class CustomResponse
    {
        HttpStatusCode statusCode;
        string message = string.Empty;

        public CustomResponse(HttpStatusCode statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }
    }
}
