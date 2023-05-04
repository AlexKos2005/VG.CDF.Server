using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class AlarmEventDescriptionsWithExternalIdRequestDto
    {
        public int AlarmEventExternalId { get; set; }

        public AlarmEventDescriptionRequestDto AlarmEventDescriptionRequestDto { get;set; }
    }
}
