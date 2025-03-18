namespace EmployeeSerierManagemt.API.Dtos
{
    public class SeriesRequestDto
    {
        public int Code { get; set; }
        public int ExternalEmployeeIdf { get; set; }             
        public string? Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
