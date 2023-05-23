using System;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto;

public class RoleDto : EntityBaseDto
{
    public string RoleName { get; set; } = string.Empty;

    public RoleCodes RoleCode { get; set; }
}