using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class RoleResponseDto
    {
      
        public int Id { get; set; }
        
        public string RoleName { get; set; }

        public RoleCodes RoleCode { get; set; }
    }
}
