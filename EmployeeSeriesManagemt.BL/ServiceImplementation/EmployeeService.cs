using EmployeeSeriesManagemt.BL.IService;
using EmployeeSeriesManagemt.Entities.Entity;
using EmployeeSeriesManagemt.Repository.Interface;

namespace EmployeeSeriesManagemt.BL.ServiceImplementation
{
    public class EmployeeService(IEmployeeRepository employeeRepo) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo = employeeRepo;

        public HashSet<Address> GetAddressByCity(string cityName, int addressTypeId)
        {
            return _employeeRepo.GetAddressByCity(cityName, addressTypeId)
                                .ToHashSet();
        }

        public IEnumerable<Address> GetAddressesByEmployeeId(int externalEmployeeIdf)
        {
            return _employeeRepo.GetAddressesByEmployeeId(externalEmployeeIdf);
        }

        public Task<Employee> GetEmployeeById(int externalEmployeeIdf)
        {
            return _employeeRepo.GetEmployeeById(externalEmployeeIdf);
        }

        public Task<Series> GetEmployeeSeriesByCode(int seriesCode)
        {
            return _employeeRepo.GetEmployeeSeriesByCode(seriesCode);
        }

        public HashSet<Series> GetEmployeeSeriesByPeriod(int externalEmployeeIdf, DateOnly startDate, DateOnly endDate)
        {
            return _employeeRepo.GetEmployeeSeriesByPeriod(externalEmployeeIdf, startDate, endDate)
                                .ToHashSet();
        }

        public Task<Employee> SaveNewEmployee(Employee employee)
        {
            return _employeeRepo.SaveNewEmployee(employee);
        }

        public async Task<Series> SaveNewEmployeeSeries(Series series)
        {
            var newEmployeeSeries = await _employeeRepo.SaveNewEmployeeSeries(series);
            
            return newEmployeeSeries.Code > 0 ? newEmployeeSeries 
                                              : new Series();
        }
    }
}
