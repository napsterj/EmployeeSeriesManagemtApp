namespace EmployeeSerierManagemt.API.Dtos
{
    public class EmployeeAddressResponseDto
    {
        public AddressDto Address { get; set; }
        //public HashSet<string>? EmployeeNames { get; set; }
        public List<Tuple<string,int>>? EmployeeNamesId { get; set; }
    }
}
