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
   public class ParameterValue 
    {
        public long Id { get; set; }

        public int ParameterExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public string Value { get; set; }

        public ParameterValueType ValueType { get; set; }

        public Guid ProcessId { get; set; }
        public long ParameterValuesGroupId { get; set; }
        public ParameterValuesGroup ParameterValuesGroup { get; set; }
    }
}
