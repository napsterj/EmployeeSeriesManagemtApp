using System.Net;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class ResponseDto
    {        
        public object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
