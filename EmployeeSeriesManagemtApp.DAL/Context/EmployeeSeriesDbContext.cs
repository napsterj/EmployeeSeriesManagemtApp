using EmployeeSeriesManagemt.Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSeriesManagemtApp.DAL.Context
{
    public class EmployeeSeriesDbContext: DbContext
    {
        public EmployeeSeriesDbContext(DbContextOptions<EmployeeSeriesDbContext> options) 
                                    : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<EmployeeIdCard> EmployeeIdCards { get; set; }
    }
}
