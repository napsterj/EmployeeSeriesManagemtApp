using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeSeriesManagemt.Frontend.Models
{    
    public class AddressDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("country")]
        [Required(ErrorMessage ="Country is mandatory")]
        [StringLength(maximumLength: 50)]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        [Required(ErrorMessage = "City is mandatory")]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }

        [JsonPropertyName("zipCode")]
        [Required(ErrorMessage = "ZipCode is mandatory")]
        [StringLength(maximumLength: 5,ErrorMessage ="Zip code must be 5 digits in length",MinimumLength =5)]
        public string ZipCode { get; set; }

        [JsonPropertyName("street")]
        [Required(ErrorMessage = "Street is mandatory")]
        [StringLength(maximumLength: 60)]
        public string Street { get; set; }

        [JsonPropertyName("number")]
        [Required(ErrorMessage = "Number is mandatory")]
        [StringLength(maximumLength: 10)]
        public string Number { get; set; }

        [JsonPropertyName("mailBoxNumber")]
        [StringLength(maximumLength: 10)]
        public string MailBoxNumber { get; set; }

        [JsonPropertyName("building")]
        [Required(ErrorMessage = "Building is mandatory")]
        [StringLength(maximumLength: 40)]
        public string Building { get; set; }

        [JsonPropertyName("floor")]
        [StringLength(maximumLength: 10)]
        public string Floor { get; set; }

        [JsonPropertyName("addressType")]
        public AddressTypeDto AddressType { get; set; } = new();
    }
}
