using System.ComponentModel.DataAnnotations;

namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class EmployeePersonalAddressVM
    {
        [Required]
        [Display(Name ="Search Term")]
        public string SearchTerm { get; set; } = string.Empty;
        public List<EmployeeAddressResponseDto> EmployeesAddresses { get; set; } = new();
    }
}
