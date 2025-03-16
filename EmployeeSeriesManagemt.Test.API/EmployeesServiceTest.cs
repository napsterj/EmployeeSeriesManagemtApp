using EmployeeSerierManagemt.API.Controllers;
using EmployeeSeriesManagemt.BL.IService;
using EmployeeSeriesManagemt.BL.ServiceImplementation;
using EmployeeSeriesManagemt.Entities.Entity;
using EmployeeSeriesManagemt.Repository.Interface;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeSeriesManagemt.Test.API
{
    public class EmployeesServiceTest
    {
        private readonly EmployeeService _sut;
        private readonly Mock<IEmployeeRepository> _employeeRepoMock = new Mock<IEmployeeRepository>();        

        public EmployeesServiceTest()
        {
            _sut = new EmployeeService(_employeeRepoMock.Object);
        }

        [Fact]
        public void GetPersonalAddressByCity_ShouldReturnEmployees_WhenCityNameIsSupplied()
        {
            //Arrange
            string cityName = "Brussels";
            var hsAddresses = new HashSet<Address>
            {
                new Address()
                {
                     Id = 10,
                     Country = "Belgium",
                     City  = "Brussels",
                     ZipCode = "12345",
                     Street = "East Street",
                     Number = "23",
                     MailBoxNumber = "7",
                     Building = "Smith Residences",
                     Floor = "3",
                     AddressTypeId = 1
                },

                new Address()
                {
                     Id = 11,
                     Country = "USA",
                     City  = "Los Angeles",
                     ZipCode = "90210",
                     Street = "Hollywood Street",
                     Number = "15",
                     MailBoxNumber = "25",
                     Building = "Beverly Apartments",
                     Floor = "10",
                     AddressTypeId = 2
                }
            };

            _employeeRepoMock.Setup(x => x.GetAddressByCity(cityName)).Returns(hsAddresses);


            //Act
            var actualAddresses = _sut.GetAddressByCity(cityName);
            

            //Assert

            Assert.NotNull(actualAddresses);
            Assert.Equal(hsAddresses.Count, actualAddresses.Count);
        }


        [Fact]
        public void GetAddressesByEmployeeId_ShouldReturnAddressAndEmployeeName_WhenIdIsSupplied()
        {
            //Arrange
            int externalemployeeIdf = 1;
            string employeeName = "John";

             var (addresses, empName) = (new HashSet<Address>
                {
                    new Address()
                    {
                         Id = 10,
                         Country = "Belgium",
                         City  = "Brussels",
                         ZipCode = "12345",
                         Street = "East Street",
                         Number = "23",
                         MailBoxNumber = "7",
                         Building = "Smith Residences",
                         Floor = "3",
                         AddressTypeId = 1
                    },

                    new Address()
                    {
                         Id = 11,
                         Country = "USA",
                         City  = "Los Angeles",
                         ZipCode = "90210",
                         Street = "Hollywood Street",
                         Number = "15",
                         MailBoxNumber = "25",
                         Building = "Beverly Apartments",
                         Floor = "10",
                         AddressTypeId = 2
                    }
                }, employeeName);

            _employeeRepoMock.Setup(x => x.GetAddressesByEmployeeId(externalemployeeIdf)).Returns((addresses, employeeName));


            //Act
            var (actualAddresses,name) = _sut.GetAddressesByEmployeeId(externalemployeeIdf);


            //Assert

            Assert.NotNull(actualAddresses);
            Assert.Equal(addresses.Count, actualAddresses.Count());
            Assert.Equal(employeeName, empName);
        }
    }
}