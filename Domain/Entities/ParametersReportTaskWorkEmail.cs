
using System;

namespace VG.CDF.Server.Domain.Entities;

public class ParametersReportTaskWorkEmail
{
    public Guid Id { get; set; }
    
    public Guid? ParameterReportTaskId { get; set; }
    public ParameterReportTask? ParameterReportTask { get; set; }

    public Guid? WorkEmailId { get; set; }
    public WorkEmail? WorkEmail { get; set; }
}