
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class TagParamResponseDto
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public TagValueTypeCodes ValueType { get; set; }
    }
}
