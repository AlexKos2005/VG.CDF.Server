using System.Collections.Generic;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.Client
{
    public class TagParamWithDescriptions
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public TagValueTypeCodes ValueType { get; set; }

        public bool IsEnabled { get; set; }

        public List<DescriptionDto> TagParamDescriptions { get; set; } = new List<DescriptionDto>();
    }
}
