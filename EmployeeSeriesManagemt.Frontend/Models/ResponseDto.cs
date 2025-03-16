using System.Net;

namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class ResponseDto
    {
        //public string? PropValue { get; set; }
        public object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
