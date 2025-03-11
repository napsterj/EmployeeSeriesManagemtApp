using EmployeeSeriesManagemt.Entities.Entity;
using EmployeeSeriesManagemt.Repository.Interface;
using EmployeeSeriesManagemtApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

namespace EmployeeSeriesManagemt.Repository.Implementation
{
    public class EmployeeRepository(EmployeeSeriesDbContext context) : IEmployeeRepository
    {
        private readonly EmployeeSeriesDbContext _context = context;

        public IEnumerable<Address> GetAddressByCity(string cityName, int addressTypeId)
        {
            //IQueryable for deferred execution of condition.
            IQueryable<Address> address = _context.Addresses.AsNoTracking();

            //Applying filtering on database side.
            var filteredEmployeeAddress  = address.Where(a => a.AddressTypeId == addressTypeId &&
                                                      a.City.Equals(cityName, 
                                                                    StringComparison.CurrentCultureIgnoreCase));
                                                      
            var employees = filteredEmployeeAddress.SelectMany(a => a.Employees)
                                           .AsEnumerable();

            if(employees != null)
            {
                return filteredEmployeeAddress.AsEnumerable();
            }

            return [];
        }

        public IEnumerable<Address> GetAddressesByEmployeeId(int externalEmployeeIdf)
        {
            var employeeAddress = _context.Employees
                                          .AsNoTracking()
                                          .Where(e => e.ExternalIdf == externalEmployeeIdf)
                                          .SelectMany(e => e.Addresses);
            
            if (employeeAddress is not null) 
            {
                return employeeAddress.AsEnumerable();
            }

            return [];            
        }

        public async Task<Employee> GetEmployeeById(int externalEmployeeIdf)
        {
            var response = await _context.Employees
                                         .FirstOrDefaultAsync(e => e.ExternalIdf == externalEmployeeIdf);

            return response!;
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
                                   .SelectMany(e => e.Series!)];                         
            }

            return [];
        }

        public async Task<Employee> SaveNewEmployee(Employee employee)
        {
            //New employee scenario
            if(employee.ExternalIdf == 0)
            {
                try
                {
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();

                    if (employee.EmployeeCard != null)
                    {
                        employee.EmployeeCard.EmployeesExternalIdf = employee.ExternalIdf;
                        _context.EmployeeIdCards.Add(employee.EmployeeCard);
                        await _context.SaveChangesAsync();
                    }

                    _context.Addresses.AddRange(employee.Addresses);
                    await _context.SaveChangesAsync();

                }
                catch
                {
                    throw;                    
                }                
            }
            
            return employee;
        }

        public async Task<Series> SaveNewEmployeeSeries(Series series)
        {
            //Checking if the series exists already
            var existingSeries = await _context.Series.FirstOrDefaultAsync(s => s.Code == series.Code);
            
            int externalEmployeeIdf = series.ExternalEmployeeIdf;
                        
            if(existingSeries is not null && (existingSeries?.ExternalEmployeeIdf == externalEmployeeIdf))
            {
                _context.Series.Add(series);
                await _context.SaveChangesAsync();
            }
            
            return series;
        }
    }
}
