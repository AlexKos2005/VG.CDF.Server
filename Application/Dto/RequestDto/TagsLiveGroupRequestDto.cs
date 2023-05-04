using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class TagsLiveGroupRequestDto
    {
        public TagsGroupRequestDto TagsGroup { get; set; }

        public List<TagLiveRequestDto> TagsLive { get; set; }
    }
}
