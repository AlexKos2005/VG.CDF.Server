using System;

namespace VG.CDF.Server.Application.Dto;

public class AlarmEventDto : EntityBaseDto
{
    public Guid Id { get; set; }

    public int ExternalId { get; set; }

    public int CompanyId { get; set; }

}