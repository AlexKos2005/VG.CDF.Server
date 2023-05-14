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

namespace VG.CDF.Server.Application.QueryBase;

public class GetQueryBase<TRequest,TDto,TEntity> : IRequestHandler<TRequest,TDto>
where TRequest: EntityBaseDto,IRequest<TDto>
where TDto : EntityBaseDto
where TEntity : EntityBase
{
    private readonly ISqlDataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IValidator<TRequest>? _validator;

    public GetQueryBase(ISqlDataContext dataContext,IMapper mapper,IValidator<TRequest>? validator)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<TDto> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if(_validator != null)
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        IQueryable<TEntity> queryableEntity;

        var context = _dataContext.Set<TEntity>();
        
        foreach (var prop in request.GetType().GetProperties())
        {
            if(prop.GetValue(prop) == null)
                continue;
            else
            {
                //var entProp = context.Where(c => c.GetType().GetProperties().Where(p => p.Name == prop.Name).First());

                var ent = await context.Where(c => c.Id == request.Id).FirstAsync(cancellationToken);

                var entProp = ent.GetType().GetProperties().FirstOrDefault(c => c.Name == prop.Name);

                if(entProp == null)
                    continue;
                
                var val1 = entProp.GetValue(ent, null);
                var val2 = entProp.GetValue(request, null);
                
                queryableEntity = queryableEntity.Where(c=>c)
                 
                

                queryableEntity = queryableEntity.Where(c =>
                {
                    var tt = c.GetType().GetProperties().FirstOrDefault(c => c.Name == prop.Name);
                    if (tt == null)
                        return false;
                    return true;

                });


            }
        }


        var entity = _mapper.Map<TEntity>(request);

        await _dataContext.Set<TEntity>().AddAsync(entity,cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TDto>(entity);
    }
}