using System.ComponentModel.DataAnnotations;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class AddressType
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        public string Description { get; set; } = string.Empty;
        public ICollection<Address> Address { get; set; } = new List<Address>();
    }
}
