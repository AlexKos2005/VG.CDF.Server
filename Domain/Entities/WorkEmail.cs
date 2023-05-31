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
    public class WorkEmail : EntityBase
    {
        public string Email { get; set; }
        
        public ICollection<ParametersReportTaskWorkEmail> ParametersReportTaskWorkEmails { get; set; }

    }
}
