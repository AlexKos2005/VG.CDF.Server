using System;

namespace VG.CDF.Server.Application.Dto.ResponseDto;

public class AlarmEventLiveDto
{
    public long Id { get; private set; }

    public int ExternalId { get; set; }

    //Время фиксации
    public DateTime DateTime { get; set; }

    //Время фиксации в UTC
    public DateTimeOffset DateTimeOffset { get; set; }

    public Guid ProcessId { get; set; }
}