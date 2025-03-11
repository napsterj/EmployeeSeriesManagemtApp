using EmployeeSeriesManagemt.Entities.Entity;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class SeriesDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ExternalEmployeeIdf { get; set; } 
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
