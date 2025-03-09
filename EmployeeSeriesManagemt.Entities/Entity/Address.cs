using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class Address
    {
        public int Id { get; set; }
               
        [StringLength(maximumLength: 50)]
        public string Country { get; set; }

        [StringLength(maximumLength: 50)]
        public string City { get; set; }

        [StringLength(maximumLength: 5)]
        public string ZipCode { get; set; }

        [StringLength(maximumLength: 60)]
        public string Street { get; set; }
        
        [StringLength(maximumLength: 10)]
        public string Number { get; set; }

        [StringLength(maximumLength: 10)]
        public string MailBoxNumber { get; set; }

        [StringLength(maximumLength: 40)]
        public string Building { get; set; }

        [StringLength(maximumLength: 10)]
        public string Floor { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; } = new AddressType();        
    }
}
