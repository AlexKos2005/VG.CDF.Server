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
    [Index(nameof(CompanyId),nameof(ExternalId), IsUnique = true)]
    public class Parameter
    {
        public Parameter()
        {
            ParametersProcesses = new List<ParameterProcess>();
            ParametersDescriptions = new List<ParameterDescription>();
            ParametersReports = new List<ParameterReport>();
        }
        [Key]
        public Guid Id { get; set; }

        public int ExternalId { get; set; }

        public ParameterValueType ValueType { get; set; }
        
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        
        public int ParameterGroupId { get; set; }
        [ForeignKey(nameof(ParameterGroupId))]
        public ParameterGroup ParameterGroup { get; set; }

        public List<ParameterProcess> ParametersProcesses { get; set; }
        public List<ParameterDescription> ParametersDescriptions { get; set; }

        public List<ParameterReport> ParametersReports { get; set; }
    }
}
