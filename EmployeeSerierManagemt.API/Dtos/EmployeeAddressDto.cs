using System.ComponentModel.DataAnnotations;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class EmployeeAddressDto
    {
        [Required(ErrorMessage ="City cannot be empty.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address type id cannot be empty and should be greater than 0")]        
        public int AddressTypeId { get;set; }
        //public AddressDto? Address { get; set; } 
        //public EmployeeDto? Employee { get; set; }
    }
}
