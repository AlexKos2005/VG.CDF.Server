using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class AlarmEventDescription: EntityBase
    {
        public string Description { get; set; }

        public Guid AlarmEventId { get; set; }
        
        public AlarmEvent AlarmEvent { get; set; }

        public Guid LanguageId { get; set; }
        
        public Language Language { get; set; }
    }
}
