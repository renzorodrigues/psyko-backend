using System.Net;

namespace CCAU.Helpers.Utils
{
    public class ResponseContent
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; } = new object();
    }
}