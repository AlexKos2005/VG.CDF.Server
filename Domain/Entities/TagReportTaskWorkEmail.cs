using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreadCommunityWeb.Blz.Domain.Entities;

public class TagReportTaskWorkEmail
{

    public int TagReportTaskId { get; set; }
    public TagReportTask TagReportTask { get; set; }

    public int WorkEmailId { get; set; }
    public WorkEmail WorkEmail { get; set; }
}