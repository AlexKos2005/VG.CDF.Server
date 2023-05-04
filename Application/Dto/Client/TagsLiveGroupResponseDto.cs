using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;

namespace VG.CDF.Server.Application.Dto.Client
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
