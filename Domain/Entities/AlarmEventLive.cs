﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class AlarmEventLive
    {
        public long Id { get; set; }

        public int ExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }
        
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }
       
    }
}
