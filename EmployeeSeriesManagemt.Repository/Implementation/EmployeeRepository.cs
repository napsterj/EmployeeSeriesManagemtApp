using EmployeeSeriesManagemt.Entities.Entity;
using EmployeeSeriesManagemt.Repository.Interface;
using EmployeeSeriesManagemtApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Security.Principal;
using System.Transactions;

namespace EmployeeSeriesManagemt.Repository.Implementation
{
    public class EmployeeRepository(EmployeeSeriesDbContext context) : IEmployeeRepository
    {
        private const int PERSONAL_ADDRESS = 1;
        
        private readonly EmployeeSeriesDbContext _context = context;

        public IEnumerable<Address> GetAddressByCity(string cityName)
        {
            //IQueryable for deferred execution of condition.
            IQueryable<Address> address = _context.Addresses
                                                  .Include(x => x.AddressType)
                                                  .Include(x=>x.Employees)
                                                  .AsNoTracking();

            //Applying filtering on database side.
            var filteredEmployeeAddress = address.Where(a => a.AddressTypeId == PERSONAL_ADDRESS &&                                                        
                                                        a.City == cityName);

            var employees = filteredEmployeeAddress.SelectMany(a => a.Employees)
                                                   .AsEnumerable();

            if (employees != null)
            {
                return filteredEmployeeAddress.AsEnumerable();
            }

            return [];
        }

        public (IEnumerable<Address>, string) GetAddressesByEmployeeId(int externalEmployeeIdf)
        {
            var employeeAddress = _context.Employees
                                          .AsNoTracking()
                                          .Where(e => e.ExternalIdf == externalEmployeeIdf)
                                          .SelectMany(e => e.Addresses);

            if (employeeAddress is not null)
            {
                var addresses = employeeAddress.AsNoTracking()
                                               .Include(x=>x.AddressType)
                                               .Where(x=>x.AddressTypeId == 1)
                                               .AsEnumerable();

                var employee = Task.Run(() => GetEmployeeById(externalEmployeeIdf))
                                                .GetAwaiter()
                                                .GetResult();
                
                if (employee is not null) 
                {
                    return (addresses, String.Concat(employee.FirstName," ", employee.LastName));
                }

            }

            return ([], string.Empty);
        }

        public async Task<Employee> GetEmployeeById(int externalEmployeeIdf)
        {
            try
            {
                var response = await _context.Employees
                                                .Include(x => x.Series)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(e => e.ExternalIdf == externalEmployeeIdf);
                if (response != null)
                {
                    response.EmployeeCard = new EmployeeIdCard();
                    response.Series = response.Series ?? new List<Series>();
                    return response;
                }
            }
            catch(Exception ex)
            {

            }

            return new Employee();
        }

        public async Task<Series> GetEmployeeSeriesByCode(int seriesCode)
        {
            var series = await _context.Series.FirstOrDefaultAsync(s => s.Code == seriesCode);
            return series;
        }

        public IEnumerable<Series> GetEmployeeSeriesByPeriod(int externalEmployeeIdf,
                                                             DateOnly startDate, DateOnly endDate)
        {
            //IQueryable for deferred execution of condition.
            IQueryable<Series> series = _context.Series.AsNoTracking();

            //Applying filtering on database side dataset size is unpredictable as date range can be few days to many years also.
            var employees = series.Where(s => s.StartDate >= startDate && s.EndDate <= endDate)
                                  .SelectMany(a => a.Employees!);

            if (employees is not null)
            {
                return [..employees.Where(e => e.ExternalIdf == externalEmployeeIdf)
                                   .SelectMany(e => e.Series!).Distinct()];
            }

            return [];
        }

        public async Task<Employee> SaveNewEmployee(Employee employee)
        {

            //New employee scenario
            if (employee.ExternalIdf == 0)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {                                                
                        _context.Employees.Add(employee);                     
                        
                        if (employee.EmployeeCard != null)
                        {                           
                            _context.EmployeeIdCards.Add(employee.EmployeeCard);                            
                        }
                        
                        foreach(var address in employee.Addresses)
                        {
                            _context.Addresses.Add(address);                        
                        }

                        if (employee.Series != null)
                        {
                            foreach (var series in employee.Series)
                            {
                                _context.Series.Add(series);
                            }
                        }

                        await _context.SaveChangesAsync();

                        // Whenever I was adding a new employee to the database with address and series, two empty rows were automatically
                        //inserted in the AddressType table.
                        //I had to write the below hack as a way to fix the above issue (screenshot in the email). Here I am updating the
                        //AddressTypeId back to 1 - Personal and 2 - Work 

                        var addresses = (from at in _context.AddressTypes
                                      join ad in _context.Addresses on at.Id equals ad.AddressTypeId
                                      where ad.AddressTypeId != 1 && ad.AddressTypeId != 2
                                      select ad).ToList();

                        for(int i = 0; i < addresses.Count; i++)
                        {
                            addresses[i].AddressTypeId = i + 1;
                            await _context.SaveChangesAsync();
                        }
                        
                        transaction.Commit();                                            
                    }
                    catch (Exception ex) 
                    {
                        transaction.Rollback();
                        throw new Exception("Error saving the new employee Data");
                    }
                }
            }

            return employee;
        }

        public async Task<Series> SaveNewEmployeeSeries(Series series)
        {
            //Checking if the series exists already
            var existingSeries = await _context.Series.FirstOrDefaultAsync(s => s.ExternalEmployeeIdf == series.ExternalEmployeeIdf);
                        
            int externalEmployeeIdf = series.ExternalEmployeeIdf;
            var ownerSeries = await _context.Employees.FirstOrDefaultAsync(e => e.ExternalIdf == externalEmployeeIdf);
            
            if (ownerSeries is not null)
            {                
                _context.Series.Add(series);
                await _context.SaveChangesAsync();
                
                ownerSeries?.Series?.Add(series);
                await _context.SaveChangesAsync();
            }

            return series;
        }

        public async Task<Employee> VerifyNewEmployeeContactDetailsNotExist(Employee employee)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmailAddress == employee.EmailAddress ||
                                                                               e.PhoneNumber == employee.PhoneNumber ||
                                                                               e.Number == employee.Number);
            return existingEmployee;
        }
    }
}
