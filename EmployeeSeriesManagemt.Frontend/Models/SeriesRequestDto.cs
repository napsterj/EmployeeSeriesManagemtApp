using System.ComponentModel.DataAnnotations;

namespace EmployeeSeriesManagemt.Frontend.Models
{
    public class SeriesRequestDto
    {
        public int Code { get; set; }
        public int ExternalEmployeeIdf { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
