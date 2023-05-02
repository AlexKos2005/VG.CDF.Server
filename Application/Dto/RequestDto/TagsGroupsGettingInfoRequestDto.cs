using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class TagsGroupsGettingInfoRequestDto
    {
        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
