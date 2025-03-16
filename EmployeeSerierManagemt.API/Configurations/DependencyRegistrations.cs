using EmployeeSerierManagemt.API.Common;
using EmployeeSeriesManagemt.BL.IService;
using EmployeeSeriesManagemt.BL.ServiceImplementation;
using EmployeeSeriesManagemt.Entities.Entity;
using EmployeeSeriesManagemt.Repository.Implementation;
using EmployeeSeriesManagemt.Repository.Interface;
using EmployeeSeriesManagemtApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSerierManagemt.API.Configurations
{
    public static class DependencyRegistrations
    {
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            
            builder.Services.AddDbContext<EmployeeSeriesDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<DbContext, EmployeeSeriesDbContext>();
            builder.Services.AddScoped<ModelStateFilterAttribute>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();            
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            
            return builder;
        }
    }
}
