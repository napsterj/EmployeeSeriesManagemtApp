using EmployeeSeriesManagemt.Frontend.Models;

namespace EmployeeSeriesManagemt.Frontend.Services.IServices
{
    public interface IEmployeeService
    {
        Task<ResponseDto> GetEmployeeAddressById(int externalEmployeeId);
        Task<ResponseDto> GetPersonalAddressesByCity(string city);
        Task<ResponseDto> GetEmployeeById(int externalEmployeeId);

        //Task<ResponseDto> GetEmployeeSeriesByDates(SeriesRequestDto requestDto);
        //Task<ResponseDto> SaveEmployee(EmployeeDto employeeDto);
        Task<ResponseDto> SaveEmployeeSeries(SeriesRequestDto seriesRequestDto);
    }
}
