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
    [Index(nameof(ReportSchemaId), nameof(TagParamId), IsUnique = true)]
    public class TagParamReport
    {
        [Key]
        public int Id { get; set; }

        public int NumberInQueue { get; set; }

        public int ReportSchemaId { get; set; }

        [ForeignKey(nameof(ReportSchemaId))]
        public ReportSchema ReportSchema { get; set; }

        public int TagParamId { get; set; }

        [ForeignKey(nameof(TagParamId))]
        public TagParam TagParam { get; set; }
    }
}
