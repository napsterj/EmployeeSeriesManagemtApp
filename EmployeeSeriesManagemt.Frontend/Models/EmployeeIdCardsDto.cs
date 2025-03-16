namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class EmployeeIdCardsDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateOnly Validity { get; set; }        
        public int? EmployeesExternalIdf { get; set; }        
    }
}
