
namespace VG.CDF.Server.Domain.Entities;

public class ParametersReportTaskWorkEmail
{

    public int TagReportTaskId { get; set; }
    public ParameterReportTask ParameterReportTask { get; set; }

    public int WorkEmailId { get; set; }
    public WorkEmail WorkEmail { get; set; }
}