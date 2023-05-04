
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class TagParamRequestDto
    {
        public int Id { get; private set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public TagValueTypeCodes ValueType { get; set; }
    }
}
