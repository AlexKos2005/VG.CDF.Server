﻿using System;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto
{
    public class ParameterReportTaskDto : EntityBaseDto
    {
        public Guid ProjectId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public  ReportTaskStatus Status { get; set; }
        
    }
}
