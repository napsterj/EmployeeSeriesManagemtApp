using EmployeeSeriesManagemt.Entities.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Globalization;

namespace EmployeeSerierManagemt.API.Dtos
{
    public class EmployeeDto
    {
        public int ExternalIdf { get; set; } = 0;

        [StringLength(maximumLength: 10)]
        public string? UserId { get; set; }
        public int Number { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        [StringLength(maximumLength: 50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is mandatory")]
        [StringLength(maximumLength: 50)]
        public string LastName { get; set; } = string.Empty;

        public string? SecondName { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Birth Place is mandatory")]
        [StringLength(maximumLength: 50)]
        public string BirthPlace { get; set; } = string.Empty;

        [Required(ErrorMessage = "Profile image is mandatory")]
        public string ProfileImage { get; set; }

        [StringLength(maximumLength: 3)]
        public string? Nationality { get; set; }

        [JsonProperty("exitDate")]
        private string ExitDate { get; set; } = string.Empty;

        [JsonIgnore]
        public DateOnly? exitDate
        {
            
            get { 
                if(!string.IsNullOrWhiteSpace(ExitDate)) 
                   return DateOnly.Parse(ExitDate, CultureInfo.CurrentCulture);

                return DateOnly.MinValue;
            }
        }


        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public int OrganizationalUnit { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        [StringLength(maximumLength: 30)]
        public string PhoneNumber { get; set; } = string.Empty;

        public List<AddressDto> Addresses { get; set; } = [];

        public EmployeeIdCardsDto? EmployeeIdCardsDto { get; set; }
    }
}
