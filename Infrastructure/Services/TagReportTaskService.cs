using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.TagReportTask.Commands;
using VG.CDF.Server.Application.TagReportTask.Queries;
using VG.CDF.Server.Application.WorkEmail.Commands;
using VG.CDF.Server.Domain.Entities;


namespace VG.CDF.Server.Infrastructure.Services;

public class TagReportTaskService : ITagReportTaskService
{
    private readonly ISqlDataContext _dataContext;
    private readonly IValidator<GetTagReportTasksListQuery> _getValidator;
    private readonly IValidator<CreateTagReportTaskCommand> _createValidator;
    private readonly IValidator<DeleteTagReportTaskCommand> _deleteValidator;
    private readonly IValidator<UpdateTagReportTaskCommand> _updateValidator;
    private readonly IValidator<AddWorkEmailToParameterReportTaskCommand> _addEmailValidator;
    private readonly IMapper _mapper;
    public TagReportTaskService(ISqlDataContext dataContext, 
        IValidator<CreateTagReportTaskCommand> createValidator, 
        IMapper mapper, 
        IValidator<DeleteTagReportTaskCommand> deleteValidator, 
        IValidator<UpdateTagReportTaskCommand> updateValidator, 
        IValidator<AddWorkEmailToParameterReportTaskCommand> addEmailValidator, 
        IValidator<GetTagReportTasksListQuery> getValidator)
    {
        _dataContext = dataContext;
        _createValidator = createValidator;
        _mapper = mapper;
        _deleteValidator = deleteValidator;
        _updateValidator = updateValidator;
        _addEmailValidator = addEmailValidator;
        _getValidator = getValidator;
    }

    public async Task<IEnumerable<ParameterReportTaskDto>> Get(GetTagReportTasksListQuery query, CancellationToken cts)
    {
        await _getValidator.ValidateAndThrowAsync(query, cts);

        var queryableEntities = _dataContext.Set<ParameterReportTask>()
            .AsNoTracking()
            .AsQueryable();

        if (query.Id != null)
            queryableEntities = queryableEntities.Where(c => c.Id == query.Id);
        if(query.FactoryId != null)
            queryableEntities = queryableEntities.Where(c => c.ProjectId == query.FactoryId);
        if(query.IsActive!=null)
            queryableEntities = queryableEntities.Where(c => c.IsActive == query.IsActive);
        if(query.LastSendDt!=null)
            queryableEntities = queryableEntities.Where(c => c.LastSendDt == query.LastSendDt);
        if(query.Status!=null)
            queryableEntities = queryableEntities.Where(c => c.Status == query.Status);

        var entities =await queryableEntities.ToListAsync();

        return _mapper.Map<IEnumerable<ParameterReportTaskDto>>(entities);
        
    }

    public async Task<ParameterReportTaskDto> Create(CreateTagReportTaskCommand command, CancellationToken cts)
    {
        await _createValidator.ValidateAndThrowAsync(command, cts);
        var entity = _mapper.Map<ParameterReportTask>(command);

        await _dataContext.TagReportTasks.AddAsync(entity,cts);
        await _dataContext.SaveChangesAsync(cts);
        
        return _mapper.Map<ParameterReportTaskDto>(entity);
    }

    public async Task<ParameterReportTaskDto> Update(UpdateTagReportTaskCommand command, CancellationToken cts)
    {
        await _updateValidator.ValidateAndThrowAsync(command, cts);

        var updateEntity = await _dataContext.TagReportTasks.Where(c => c.Id == command.Id).FirstAsync();
        updateEntity.IsActive = command.IsActive;
        updateEntity.LastSendDt = command.LastSendDt;
        updateEntity.Status = command.Status;

        _dataContext.TagReportTasks.Update(updateEntity);
        await _dataContext.SaveChangesAsync(cts);
        
        return _mapper.Map<ParameterReportTaskDto>(updateEntity);
    }

    public async Task<ParameterReportTaskDto> AddEmailToTagReportTask(AddWorkEmailToParameterReportTaskCommand command, CancellationToken cts)
    {
        await _addEmailValidator.ValidateAndThrowAsync(command, cts);
        var reportTask = await _dataContext.TagReportTasks.Where(c => c.Id == command.TagReportTaskId).FirstAsync();
        var workEmail = await _dataContext.WorkEmails.Where(c => c.Id == command.Id).FirstAsync();
        reportTask.WorkEmails.Add(workEmail);

        await _dataContext.SaveChangesAsync(cts);
        
        return _mapper.Map<ParameterReportTaskDto>(reportTask);
    }

    public async Task<bool> Delete(DeleteTagReportTaskCommand command, CancellationToken cts)
    {
        await _deleteValidator.ValidateAndThrowAsync(command, cts);
        var entity = await _dataContext.TagReportTasks.Where(c => c.Id == command.Id).FirstAsync();

        _dataContext.TagReportTasks.Remove(entity);
        await _dataContext.SaveChangesAsync(cts);

        return true;
    }
}
