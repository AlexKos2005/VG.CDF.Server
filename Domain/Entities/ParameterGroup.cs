using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(ExternalId), IsUnique = true)]
    public class ParameterGroup : EntityBase
    {
        public ParameterGroup()
        {
            Parameters = new List<Parameter>();
        }
        [Key]
        public override Guid Id { get; set; }

        public int ExternalId { get; set; }

        public string Name { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
