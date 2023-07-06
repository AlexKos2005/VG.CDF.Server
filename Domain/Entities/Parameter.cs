using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Domain.Entities
{
    public class Parameter: EntityBase
    {
        public override Guid Id { get; set; }

        public int ExternalId { get; set; }

        public ParameterValueType ValueType { get; set; }
        
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        
        public Guid? ParameterGroupId { get; set; }
        public ParameterGroup? ParameterGroup { get; set; }

        public ICollection<ParameterProcess> ParametersProcesses { get; set; }
        public ParameterDescription? ParametersDescription { get; set; }
        
    }
}
