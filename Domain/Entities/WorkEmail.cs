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
    public class WorkEmail
    {
        public WorkEmail()
        {
            ParametersReportTasks = new List<ParametersReportTask>();
        }
        [Key]
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public ICollection<ParametersReportTask> ParametersReportTasks { get; set; }

    }
}
