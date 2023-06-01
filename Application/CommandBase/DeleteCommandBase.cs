using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.CommandBase;

public class DeleteCommandBase<TRequest, TEntity> : IRequestHandler<TRequest,bool>
where TRequest: EntityBaseDto, IRequest<bool>
where TEntity : EntityBase
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidator<TRequest>? _validator;

    public DeleteCommandBase(ISqlDataContext dataContext,IMapper mapper,IValidator<TRequest>? validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if(_validator != null)
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var entity = await _dataContext.Set<TEntity>()
            .Where(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            return false;

        _dataContext.Set<TEntity>().Remove(entity);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}