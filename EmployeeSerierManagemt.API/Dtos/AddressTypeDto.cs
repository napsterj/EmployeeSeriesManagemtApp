using System.ComponentModel.DataAnnotations;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class AddressTypeDto
    {
        public int Id { get; set; }        
        public string Description { get; set; } = string.Empty;
    }
}
