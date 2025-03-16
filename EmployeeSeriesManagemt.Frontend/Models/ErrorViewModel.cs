namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string? RequestPath { get; set; }
        public string? Error { get; set; }        
    }
}
