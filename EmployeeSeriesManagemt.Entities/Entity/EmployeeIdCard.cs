using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class EmployeeIdCard
    {
        [Key]
        public int Id { get; set; }        
        public int Number { get; set; }
        public DateOnly Validity { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeesExternalIdf { get; set; }
        public Employee? Employee { get; set; }
    }
}
