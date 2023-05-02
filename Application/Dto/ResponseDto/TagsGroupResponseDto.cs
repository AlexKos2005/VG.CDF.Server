using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
   public class TagsGroupResponseDto
    {
        public long Id { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public List<TagLiveResponseDto> TagsLive { get; set; } = new List<TagLiveResponseDto>();

    }
}
