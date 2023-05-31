
namespace VG.CDF.Server.Domain.Entities;

public class ParametersReportTaskWorkEmail
{
    public int Id { get; set; }
    
    public int ParameterReportTaskId { get; set; }
    public ParameterReportTask ParameterReportTask { get; set; }

    public int WorkEmailId { get; set; }
    public WorkEmail WorkEmail { get; set; }
}