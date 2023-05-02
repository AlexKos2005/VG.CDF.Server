using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
   public class AlarmEventRequestDto
    {
        public int Id { get; private set; }

        public int ExternalId { get; set; }

        public int DeviceId { get; set; }
        
    }
}
