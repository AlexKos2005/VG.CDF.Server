using System;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
   public class TagLiveRequestDto
    {
        public long Id { get; set; }

        public int TagParamExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public long TagsGroupId { get; set; }

        public string Value { get; set; }

        public ParameterValueType ValueType { get; set; }

    }
}
