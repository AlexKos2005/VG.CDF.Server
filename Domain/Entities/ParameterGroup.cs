using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class ParameterGroup : EntityBase
    {
        public int ExternalId { get; set; }

        public string Name { get; set; }

        public ICollection<Parameter> Parameters { get; set; }
    }
}
