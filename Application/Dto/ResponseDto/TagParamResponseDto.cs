﻿
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class TagParamResponseDto
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public ParameterValueType ValueType { get; set; }
    }
}
