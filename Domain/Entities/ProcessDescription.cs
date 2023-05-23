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
    [Index(nameof(ProcessId), nameof(LanguageId), IsUnique = true)]
    public class ProcessDescription : EntityBase
    {
        [Key]
        public override Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ProcessId { get; set; }

        [ForeignKey(nameof(ProcessId))]
        public Process Process { get; set; }

        public Guid LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }
    }
}
