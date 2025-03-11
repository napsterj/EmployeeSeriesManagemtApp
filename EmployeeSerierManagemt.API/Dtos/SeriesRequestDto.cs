namespace EmployeeSerierManagemt.API.Dtos
{
    public class SeriesRequestDto
    {
        public int ExternalEmployeeIdf { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
