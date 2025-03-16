namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class EmployeeAddressDto
    {
        public IEnumerable<AddressDto> EmployeeAddresses { get; set; }
        public string EmployeeName { get; set; }
    }
}
