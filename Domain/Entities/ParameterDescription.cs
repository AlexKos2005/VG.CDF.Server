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
    public class ParameterDescription: EntityBase
    {
        public string RusDescription { get; set; }
        public string EngDescription { get; set; }
        
        public string UkrDescription { get; set; }
        public Guid ParameterId { get; set; }
        public Parameter Parameter { get; set; }
       
    }
}
