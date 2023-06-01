
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class RoleResponseDto
    {
      
        public int Id { get; set; }
        
        public string RoleName { get; set; }

        public RoleCode RoleCode { get; set; }
    }
}
