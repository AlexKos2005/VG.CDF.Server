using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG.CDF.Server.Application.Dto;

namespace VG.CDF.Server.WebApi.Controllers;

public abstract class ControllerBase<Tg,Tc,Tu,Td,TOut> : Controller
where Tg: IRequest<IEnumerable<TOut>>
where Tc: IRequest<TOut>
where Tu: IRequest<TOut>
where Td: EntityBaseDto,IRequest<bool>, new()
{
    protected readonly IMediator _mediator;
    public ControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TOut>> Get([FromQuery]Tg query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        return result;
    }
    
    [HttpPost]
    public async Task<TOut> Create([FromBody]Tc command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        return result;
    }
    
    [HttpPut]
    public async Task<TOut> Update([FromBody]Tu command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        return result;
    }
    
    [HttpDelete]
    public async Task<IActionResult> Update([FromQuery]Guid id, CancellationToken cts)
    {
        var command = new Td() { Id = id };
        var result = await _mediator.Send(command, cts);
        return NoContent();
    }
}