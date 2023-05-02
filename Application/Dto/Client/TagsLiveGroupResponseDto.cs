using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.Client
{
   public class TagsLiveGroupResponseDto
    {
        public long Id { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public List<TagLiveRequestDto> TagsLive { get; set; } = new List<TagLiveRequestDto>();

    }
}
