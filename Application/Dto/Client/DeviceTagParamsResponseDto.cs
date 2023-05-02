using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.Client
{
    public class DeviceTagParamsResponseDto
    {
        public DeviceWithDescriptionsDto Device { get; set; } = new DeviceWithDescriptionsDto();
        public List<TagParamWithDescriptions> TagParams { get; set; } = new List<TagParamWithDescriptions>();
    }
}
