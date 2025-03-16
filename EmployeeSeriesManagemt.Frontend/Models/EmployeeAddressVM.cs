using System.ComponentModel.DataAnnotations;

namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class EmployeeAddressVM
    {
        [Required]
        public int ExternalEmployeeIdf { get; set; }
        public string? EmployeeName { get; set; }
        public IEnumerable<AddressDto>? Addresses { get; set; } = new List<AddressDto>();
        public string? ErrorMessage { get; set; }
    }
}
