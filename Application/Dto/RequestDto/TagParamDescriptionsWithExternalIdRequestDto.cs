using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class TagParamDescriptionsWithExternalIdRequestDto
    {
        public int TagParamExternalId { get; set; }

        public TagParamDescriptionRequestDto TagParamDescriptionRequestDto { get;set; }
    }
}
