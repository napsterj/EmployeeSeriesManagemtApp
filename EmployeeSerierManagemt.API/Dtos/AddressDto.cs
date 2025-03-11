using EmployeeSeriesManagemt.Entities.Entity;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Country is mandatory")]
        [StringLength(maximumLength: 50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is mandatory")]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is mandatory")]
        [StringLength(maximumLength: 5,ErrorMessage ="Zip code must be 5 digits in length",MinimumLength =5)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Street is mandatory")]
        [StringLength(maximumLength: 60)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Number is mandatory")]
        [StringLength(maximumLength: 10)]
        public string Number { get; set; }

        [StringLength(maximumLength: 10)]
        public string MailBoxNumber { get; set; }

        [Required(ErrorMessage = "Building is mandatory")]
        [StringLength(maximumLength: 40)]
        public string Building { get; set; }

        [StringLength(maximumLength: 10)]
        public string Floor { get; set; } 
        public int AddressTypeId { get; set; }
    }
}
