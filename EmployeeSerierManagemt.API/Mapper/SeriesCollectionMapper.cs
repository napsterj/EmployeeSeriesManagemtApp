﻿using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.Entities.Entity;
using Riok.Mapperly.Abstractions;

namespace EmployeeSerierManagemt.API.Mapper
{
    [Mapper]
    public partial class SeriesCollectionMapper
    {
        public partial HashSet<SeriesDto> SeriesToSeriesDtoCollection(HashSet<Series> hsSeries);
    }
}
