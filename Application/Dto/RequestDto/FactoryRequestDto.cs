using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using BreadCommunityWeb.Blz.Domain.Entities;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
   public class FactoryRequestDto
    {
        public int Id { get; private set; }
        public int ExternalId { get; set; }

        public int UtcOffset { get; set; }

        public string Description { get; set; }

    }
}
