
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class TagParamRequestDto
    {
        public int Id { get; private set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public ParameterValueType ValueType { get; set; }
    }
}
