using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSeriesManagemt.Entities.Entity
{
    public class Employee
    {
        [Key]
        public int ExternalIdf { get; set; }

        [StringLength(maximumLength:10)]
        public string? UserId { get; set; }                      
        public int Number { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 50)]
        public string LastName { get; set; } = string.Empty;       
        
        public string? SecondName { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string BirthPlace { get; set; } = string.Empty;

        [Required]
        public byte[] ProfileImage { get; set; }

        [StringLength(maximumLength:3)]
        public string? Nationality { get; set; }

        public DateOnly? ExitDate { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public int OrganizationalUnit { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        [NotMapped]
        [ForeignKey("Series")]
        public int SeriesCode { get; set; }        
        public ICollection<Series>? Series { get; set; }        

        [NotMapped]
        public EmployeeIdCard? EmployeeCard { get; set; }
       
    }
}
