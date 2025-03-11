using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.Entities.Entity;
using Riok.Mapperly.Abstractions;

namespace EmployeeSerierManagemt.API.Mapper
{
    [Mapper]
    public partial class SeriesResponseMapper
    {
        public partial Series SeriesDtoToSeries(SeriesDto seriesDto);
    }
}
