using EmployeeSeriesManagemt.Frontend.Models;
using EmployeeSeriesManagemt.Frontend.Services.IServices;

namespace EmployeeSeriesManagemt.Frontend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseService _baseService;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl = string.Empty;

        public EmployeeService(IBaseService baseService, IConfiguration configuration)
        {
            _baseService = baseService;
            _configuration = configuration;
            baseUrl = _configuration["ApiConfig:EmployeeApiBaseUrl"]!;
        }

        public Task<ResponseDto> GetEmployeeAddressById(int externalEmployeeId)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = AppConstants.ApiType.POST,
                Url = $"{baseUrl}/api/Employees/get/employee/addresses/",
                Data = externalEmployeeId
            });
        }

        public Task<ResponseDto> GetEmployeeById(int externalEmployeeId)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = AppConstants.ApiType.POST,
                Url = $"{baseUrl}/api/Employees/get/employee/profile/",
                Data = externalEmployeeId
            });
        }

        //public Task<ResponseDto> GetEmployeeSeriesByDates(SeriesRequestDto requestDto)
        //{
        //    return _baseService.SendAsync(new RequestDto
        //    {
        //        ApiType = AppConstants.ApiType.GET,
        //        Url = $"{baseUrl}/api/Employees/get/employee/series/datewise/",
        //        Data = requestDto
        //    });
        //}

        public Task<ResponseDto> GetPersonalAddressesByCity(string city)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = AppConstants.ApiType.POST,
                Url = $"{baseUrl}/api/Employees/get/employee/address/personal/",
                Data = city
            });
        }


        //public Task<ResponseDto> SaveEmployee(EmployeeDto employeeDto)
        //{
        //    return _baseService.SendAsync(new RequestDto
        //    {
        //        ApiType = AppConstants.ApiType.POST,
        //        Url = $"{baseUrl}/api/Employees/add/employee/new/",
        //        Data = employeeDto
        //    });
        //}

        public Task<ResponseDto> SaveEmployeeSeries(SeriesRequestDto seriesRequestDto)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = AppConstants.ApiType.POST,
                Url = $"{baseUrl}/api/Employees/add/employee/series/",
                Data = seriesRequestDto
            });
        }
    }
}
