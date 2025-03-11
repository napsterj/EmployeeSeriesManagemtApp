using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.Entities.Entity;
using Riok.Mapperly.Abstractions;

namespace EmployeeSerierManagemt.API.Mapper
{
    [Mapper]
    public partial class AddressMapper
    {
        public partial AddressDto AddressToAddressDto(Address address);
        public partial IEnumerable<AddressDto> AddressesToAddressesDto(IEnumerable<Address> addresses);
    }
}
