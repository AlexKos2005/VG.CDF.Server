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
    [Index(nameof(Email), IsUnique = true)]
    public class WorkEmail : EntityBase
    {
        public WorkEmail()
        {
            ParametersReportTasks = new List<ParameterReportTask>();
        }
        [Key]
        public override Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public ICollection<ParameterReportTask> ParametersReportTasks { get; set; }

    }
}
