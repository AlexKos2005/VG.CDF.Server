
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class RoleRequestDto
    {
        public int Id { get; private set; }
        
        public string RoleName { get; set; }

        public RoleCode RoleCode { get; set; }

    }
}
