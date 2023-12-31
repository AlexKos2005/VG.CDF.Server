﻿using System;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto;

public class ParameterDto : EntityBaseDto
{
    public int ExternalId { get; set; }

    public ParameterValueType ValueType { get; set; }
        
    public Guid CompanyId { get; set; }

    public Guid ParameterGroupId { get; set; }

}