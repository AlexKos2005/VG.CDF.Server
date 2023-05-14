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
    [Index(nameof(ParameterId), nameof(LanguageId), IsUnique = true)]
    public class ParameterDescription: EntityBase
    {
        [Key]
        public override Guid Id { get; set; }

        public string Description { get; set; }

        public int ParameterId { get; set; }

        [ForeignKey(nameof(ParameterId))]
        public Parameter Parameter { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }
    }
}
