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

public class UpdateCommandBase<TRequest, TDto,TEntity> : IRequestHandler<TRequest,TDto?>
where TRequest: EntityBaseDto, IRequest<TDto>
where TDto: EntityBaseDto
where TEntity : EntityBase
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidator<TRequest>? _validator;

    public UpdateCommandBase(ISqlDataContext dataContext,IMapper mapper,IValidator<TRequest>? validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<TDto?> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if(_validator != null)
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var entity = await _dataContext.Set<TEntity>()
            .Where(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            return null;
        var updatedEntity = _mapper.Map<TEntity>(request);

        updatedEntity.Id = entity.Id;
        
        _dataContext.Set<TEntity>().Update(updatedEntity);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TDto>(updatedEntity);
    }
}