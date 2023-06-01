using System;

namespace VG.CDF.Server.Application.Dto;

public class ParameterGroupDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public string Name { get; set; } = string.Empty;
}