using EmployeeSeriesManagemt.Entities.Entity;

namespace EmployeeSeriesManagemt.BL.IService
{
    public interface IEmployeeService
    {
        IEnumerable<Address> GetAddressesByEmployeeId(int externalEmployeeIdf);
        HashSet<Address> GetAddressByCity(string cityName, int addressTypeId);
        HashSet<Series> GetEmployeeSeriesByPeriod(int externalEmployeeIdf, DateOnly startDate, DateOnly endDate);
        Task<Employee> GetEmployeeById(int externalEmployeeIdf);
        Task<Series> SaveNewEmployeeSeries(Series series);
        Task<Employee> SaveNewEmployee(Employee employee);
        Task<Series> GetEmployeeSeriesByCode(int seriesCode);
    }
}
