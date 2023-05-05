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
    [Index(nameof(ParameterId), nameof(DescriptionsLanguageId), IsUnique = true)]
    public class ParameterDescription
    {
        [Key]
        public Guid Id { get; set; }

        public string Description { get; set; }

        public int ParameterId { get; set; }

        [ForeignKey(nameof(ParameterId))]
        public Parameter Parameter { get; set; }

        public int DescriptionsLanguageId { get; set; }

        [ForeignKey(nameof(DescriptionsLanguageId))]
        public DescriptionsLanguage DescriptionsLanguage { get; set; }
    }
}
