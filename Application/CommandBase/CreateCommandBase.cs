using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.CommandBase;

public class CreateCommandBase<TRequest,TDto,TEntity> : IRequestHandler<TRequest,TDto>
where TRequest: IRequest<TDto>
where TDto : EntityBaseDto
where TEntity : EntityBase
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidator<TRequest>? _validator;

    public CreateCommandBase(ISqlDataContext dataContext,IMapper mapper,IValidator<TRequest>? validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if(_validator != null)
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var entity = _mapper.Map<TEntity>(request);

        await _dataContext.Set<TEntity>().AddAsync(entity,cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TDto>(entity);
    }
}