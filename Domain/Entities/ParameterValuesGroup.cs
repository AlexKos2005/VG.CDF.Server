using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class ParameterValuesGroup 
    {
        public long Id { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации по UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public Guid ProcessId { get; set; }
        public Process Process { get; set; }

        public ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
