using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class DeviceLanguageDescriptionResponseDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public LanguageDescriptionCodes Language { get; set; }

    }
}
