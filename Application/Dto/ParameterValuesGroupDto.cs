using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto
{
    public class ParameterValuesGroupDto
    {
        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации по UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public Guid ProcessId { get; set; }

        public ICollection<ParameterValueDto> ParameterValues { get; set; } = null!;
    }
}
