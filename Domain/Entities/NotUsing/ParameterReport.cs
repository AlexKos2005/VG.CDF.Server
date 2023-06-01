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
    public class ParameterReport
    {
        public int Id { get; set; }

        public int NumberInQueue { get; set; }

        public int ReportSchemaId { get; set; }
        
        public ReportSchema ReportSchema { get; set; }

        public int TagParamId { get; set; }
        
        public Parameter Parameter { get; set; }
    }
}
