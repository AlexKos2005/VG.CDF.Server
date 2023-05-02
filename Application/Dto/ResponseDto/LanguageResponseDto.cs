using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class LanguageResponseDto
    {
        public int Id { get; set; }

        public int LanguageExternalId { get; set; }
        public string LanguageLabel { get; set; }
    }
}
