using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class RoleRequestDto
    {
        public int Id { get; private set; }
        
        public string RoleName { get; set; }

        public RoleCodes RoleCode { get; set; }

    }
}
