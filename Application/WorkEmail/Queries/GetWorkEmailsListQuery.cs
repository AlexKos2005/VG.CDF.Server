using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.WorkEmail.Commands;

public class GetWorkEmailsListQuery
{
    public int? Id { get; set; } = null;
    
    public int? TagReportTaskId { get; set; } = null;
    public string? Email { get; set; } = null;
}

public class GetWorkEmailsListQueryValidator : AbstractValidator<GetWorkEmailsListQuery>
{
    public GetWorkEmailsListQueryValidator(ISqlDataContext dataContext)
    {
        
    }
}
