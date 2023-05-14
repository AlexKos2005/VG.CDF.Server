
using System;

namespace VG.CDF.Server.Application.Dto
{
    public class AlarmEventDescriptionDto : EntityBaseDto
    {
        public string Description { get; set; }

        public int LanguageId { get; set; }
        
        public Guid AlarmEventId { get; set; }

    }
}
