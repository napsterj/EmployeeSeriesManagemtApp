using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.Entities.Entity;
using Riok.Mapperly.Abstractions;

namespace EmployeeSerierManagemt.API.Mapper
{
    [Mapper]
    public partial class EmployeeResponseMapper
    {
        public partial EmployeeDto EmployeeToEmployeeDto(Employee employee);
    }
}
