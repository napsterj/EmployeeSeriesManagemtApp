using System.ComponentModel.DataAnnotations;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class Series
    {
        [Key]        
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }    
        public ICollection<Employee>? Employees { get; set; }
    }
}
