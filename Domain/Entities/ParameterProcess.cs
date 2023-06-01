using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VG.CDF.Server.Domain.Entities
{
    public class ParameterProcess 
    {
        public Guid Id { get; set; }
        public int ParameterId { get; set; }
        public Parameter Parameter { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }

    }
}
