using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class AddressType
    {        
        [Key]        
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        public string Description { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
