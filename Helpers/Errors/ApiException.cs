namespace CCAU.Helpers.Errors
{
    public class ApiException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string Details { get; set; }

        public ApiException(int statusCode, string exceptionType, string message = null, string details = null)
        {
            this.StatusCode = statusCode;
            this.ExceptionType = exceptionType;
            this.Message = message;
            this.Details = details;
        }        
    }
}