using System;

namespace VG.CDF.Server.Application.Dto;

public class ProcessDescriptionDto : EntityBaseDto
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }
        
    public Guid ProcessId { get; set; }
}