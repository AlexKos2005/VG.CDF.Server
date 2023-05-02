using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class DeviceDescriptionResponseDto
    {
        public int Id { get;  set; }

        public string Description { get; set; }

        public int DeviceId { get; set; }

        public int DescriptionsLanguageId { get; set; }

        public LanguageResponseDto DescriptionsLanguage { get; set; }
    }
}
