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
    [Index(nameof(AlarmEventId), nameof(LanguageId), IsUnique = true)]
    public class AlarmEventDescription: EntityBase
    {
        [Key]
        public override Guid Id { get; set; }

        public string Description { get; set; }

        public Guid AlarmEventId { get; set; }

        [ForeignKey(nameof(AlarmEventId))]
        public AlarmEvent AlarmEvent { get; set; }

        public Guid LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }
    }
}
