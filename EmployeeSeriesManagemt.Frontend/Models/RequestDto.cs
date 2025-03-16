namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class RequestDto
    {
        public Enum ApiType { get; set; }
        public string Url { get; set; } = string.Empty;
        public object Data { get; set; } = string.Empty;
    }
}
