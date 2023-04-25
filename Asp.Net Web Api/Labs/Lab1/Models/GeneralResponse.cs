using System.Net;

namespace Lab1.Models
{
    public class GeneralResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public GeneralResponse(HttpStatusCode _statusCode , string _Message)
        {
            StatusCode = _statusCode;
            Message = _Message;
        }
    }
}
