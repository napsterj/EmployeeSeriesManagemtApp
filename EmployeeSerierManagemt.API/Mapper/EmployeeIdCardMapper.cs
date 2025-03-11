using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.Entities.Entity;
using Riok.Mapperly.Abstractions;

namespace EmployeeSerierManagemt.API.Mapper
{
    [Mapper]
    public partial class EmployeeIdCardMapper
    {
        public partial EmployeeIdCard EmployeeCardDtoToEmployeeCard(EmployeeIdCardsDto employeeIdCardsDto);
    }
}
