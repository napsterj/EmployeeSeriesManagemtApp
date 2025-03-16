
namespace EmployeeSerierManagemt.API.Dtos
{
    public class EmployeeAddressDto
    {
        public IEnumerable<AddressDto> EmployeeAddresses { get; set; }
        public string EmployeeName { get; set; }
    }
}
