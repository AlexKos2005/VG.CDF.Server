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
        public ParameterValuesGroup()
        {
            ParameterValues = new List<ParameterValue>();
        }
        [Key]
        public long Id { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации по UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int ProjectExternalId { get; set; }

        public int ProcessExternalId { get; set; }

        public List<ParameterValue> ParameterValues { get; set; }
    }
}
