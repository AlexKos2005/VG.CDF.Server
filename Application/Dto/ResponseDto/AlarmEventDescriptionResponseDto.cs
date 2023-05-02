using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class AlarmEventDescriptionResponseDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public int DescriptionsLanguageId { get; set; }

        public AlarmEventResponseDto AlarmEvent { get; set; }
        public LanguageResponseDto DescriptionsLanguage { get; set; }
    }
}
