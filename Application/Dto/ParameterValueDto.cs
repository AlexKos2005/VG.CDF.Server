﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto
{ 
   public class ParameterValueDto
    {
        public Guid ParameterValuesGroupId { get; set; }
        
        public int ParameterExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public string Value { get; set; } = String.Empty;

        public ParameterValueType ValueType { get; set; }
        
    }
}
