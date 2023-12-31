﻿using System;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto;

public class RoleDto : EntityBaseDto
{
    public string RoleName { get; set; } = string.Empty;

    public RoleCode RoleCode { get; set; }
}