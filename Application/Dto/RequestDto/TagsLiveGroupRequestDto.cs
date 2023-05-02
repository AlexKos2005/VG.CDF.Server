using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class TagsLiveGroupRequestDto
    {
        public TagsGroupRequestDto TagsGroup { get; set; }

        public List<TagLiveRequestDto> TagsLive { get; set; }
    }
}
