using System;

namespace VG.CDF.Server.Application.Dto;

public class ProcessDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public int UtcOffset { get; set; }

    public string Description { get; set; } = string.Empty;
        
    public Guid ProjectId { get; set; }

}