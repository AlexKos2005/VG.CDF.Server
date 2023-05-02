using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class DeviceLanguageDescriptionRequestDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public ICollection<DeviceLanguageDescriptionRequestDto> DeviceLanguageDescriptions { get; set; }

    }
}
