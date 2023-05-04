using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.HandlerBase;

public class CreateHandlerBase<TRequest,TResponse,TEntity>  : IRequestHandler<TRequest,TResponse>
where TRequest : IRequest<TResponse>
where TResponse : class
where TEntity : class
{
    private readonly IValidator<TRequest> _validator;
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    public CreateHandlerBase(IValidator<TRequest> validator, ISqlDataContext dataContext, IMapper mapper)
    {
        _validator = validator;
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public virtual async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var entity = _mapper.Map<TEntity>(request);

        _dataContext.Set<TEntity>().Add(entity);

        await _dataContext.SaveChangesAsync();
        
        return _mapper.Map<TResponse>(request);
    }
}