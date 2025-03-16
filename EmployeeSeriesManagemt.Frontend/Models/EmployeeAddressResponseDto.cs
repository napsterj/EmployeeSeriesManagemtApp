namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class EmployeeAddressResponseDto
    {        
        public AddressDto Address { get; set; }
        //public List<string>? EmployeeNames { get; set; }
        public List<Tuple<string, int>>? EmployeeNamesId { get; set; }
    }
}
