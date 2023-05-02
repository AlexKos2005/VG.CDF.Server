using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class AlarmEventDescriptionRequestDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public int DescriptionsLanguageId { get; set; }

    }
}
