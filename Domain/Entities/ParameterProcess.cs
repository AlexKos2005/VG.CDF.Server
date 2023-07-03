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
        public Guid? ParameterId { get; set; }
        public Parameter? Parameter { get; set; }
        public Guid? ProcessId { get; set; }
        public Process? Process { get; set; }

    }
}
