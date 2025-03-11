using EmployeeSeriesManagemt.Entities.Entity;

namespace EmployeeSeriesManagemt.Repository.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Address> GetAddressesByEmployeeId(int externalEmployeeIdf);
        IEnumerable<Address> GetAddressByCity(string cityName, int addressTypeId);
        IEnumerable<Series> GetEmployeeSeriesByPeriod(int externalEmployeeIdf, DateOnly startDate, DateOnly endDate);
        Task<Employee> GetEmployeeById(int externalEmployeeIdf);
        Task<Series> GetEmployeeSeriesByCode(int seriesCode);
        Task<Series> SaveNewEmployeeSeries(Series series);
        Task<Employee> SaveNewEmployee(Employee employee);
        
    }
}
