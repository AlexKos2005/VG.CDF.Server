using System;
using System.Collections.Generic;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto.Client
{
    public class ParametersWithDescriptions
    {
        public Guid Id { get; set; }
        public int ExternalId { get; set; }
        
        public bool IsEnabled { get; set; }
        
    }
}
