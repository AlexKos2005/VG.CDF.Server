using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
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

        public TagValueTypeCodes ValueType { get; set; }

    }
}
