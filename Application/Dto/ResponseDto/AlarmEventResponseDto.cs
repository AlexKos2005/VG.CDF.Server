using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
   public class AlarmEventResponseDto
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public int DeviceId { get; set; }
    }
}
