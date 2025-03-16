using EmployeeSeriesManagemt.Entities;
using EmployeeSeriesManagemt.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Numerics;

namespace EmployeeSeriesManagemtApp.DAL.Context
{
    public class EmployeeSeriesDbContext: DbContext
    {
        public EmployeeSeriesDbContext(DbContextOptions<EmployeeSeriesDbContext> options) 
                                    : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                                    
            modelBuilder.Entity<Address>().HasKey(e => e.Id);
            modelBuilder.Entity<AddressType>().HasKey(e => e.Id);
           
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<EmployeeIdCard> EmployeeIdCards { get; set; }              
    }
}
