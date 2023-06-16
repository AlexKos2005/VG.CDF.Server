using System;

namespace VG.CDF.Server.Application.Dto;

public class ProjectDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public int UtcOffset { get; set; }

    public string Description { get; set; } = string.Empty;
        
    public Guid CompanyId { get; set; }

}