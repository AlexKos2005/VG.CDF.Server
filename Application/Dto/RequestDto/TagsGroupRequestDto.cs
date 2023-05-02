using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
   public class TagsGroupRequestDto
    {
        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации по UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public List<TagLiveRequestDto> TagLiveRequestDtos { get; set; } = new List<TagLiveRequestDto>();
    }
}
