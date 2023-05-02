using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Application.WorkEmail.Commands;
using BreadCommunityWeb.Blz.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services;

public class WorkEmailService : IWorkEmailService
{
    private readonly ISqlDataContext _dataContext;
    private readonly IValidator<GetWorkEmailsListQuery> _getValidator;
    private readonly IValidator<CreateWorkEmailCommand> _createValidator;
    private readonly IValidator<DeleteWorkEmailCommand> _deleteValidator;
    private readonly IValidator<UpdateWorkEmailCommand> _updateValidator;
    private readonly IValidator<AddWorkEmailToTagReportTaskCommand> _addToReportTaskValidator;
    private readonly IMapper _mapper; 
    public WorkEmailService(
        ISqlDataContext dataContext, 
        IValidator<CreateWorkEmailCommand> createValidator, 
        IValidator<DeleteWorkEmailCommand> deleteValidator, 
        IValidator<UpdateWorkEmailCommand> updateValidator, 
        IMapper mapper, 
        IValidator<GetWorkEmailsListQuery> getValidator, 
        IValidator<AddWorkEmailToTagReportTaskCommand> addToReportTaskValidator)
    {
        _dataContext = dataContext;
        _createValidator = createValidator;
        _deleteValidator = deleteValidator;
        _updateValidator = updateValidator;
        _mapper = mapper;
        _getValidator = getValidator;
        _addToReportTaskValidator = addToReportTaskValidator;
    }

    public async Task<IEnumerable<WorkEmailDto>> Get(GetWorkEmailsListQuery query, CancellationToken cts)
    {
        await _getValidator.ValidateAndThrowAsync(query, cts);

        var queryableEntities = _dataContext.Set<WorkEmail>()
            .AsNoTracking()
            .AsQueryable();

        if (query.Id != null)
            queryableEntities = queryableEntities.Where(c => c.Id == query.Id);
        if (query.TagReportTaskId != null)
        {
            var report = await _dataContext.Set<TagReportTask>()
                .AsNoTracking()
                .Where(c=>c.Id == query.TagReportTaskId).FirstAsync();
            queryableEntities = queryableEntities.Where(c => c.TagReportTasks.Contains(report));
        }
        if (!string.IsNullOrEmpty(query.Email))
            queryableEntities = queryableEntities.Where(c => c.Email == query.Email);

        var entities = await queryableEntities.ToListAsync();

        return _mapper.Map<IEnumerable<WorkEmailDto>>(entities);
    }

    public async Task<WorkEmailDto> Create(CreateWorkEmailCommand command, CancellationToken cts)
    {
        await _createValidator.ValidateAndThrowAsync(command, cts);
        var entity = _mapper.Map<WorkEmail>(command);

        entity.Email = entity.Email.ToLower();
        await _dataContext.WorkEmails.AddAsync(entity,cts);
        await _dataContext.SaveChangesAsync(cts);
        
        return _mapper.Map<WorkEmailDto>(entity);
    }

    public async Task<WorkEmailDto> Update(UpdateWorkEmailCommand command, CancellationToken cts)
    {
        await _updateValidator.ValidateAndThrowAsync(command, cts);

        var updateEntity = await _dataContext.WorkEmails.Where(c => c.Id == command.Id).FirstAsync();
        updateEntity.Email = command.Email;

        _dataContext.WorkEmails.Update(updateEntity);
        await _dataContext.SaveChangesAsync(cts);
        
        return _mapper.Map<WorkEmailDto>(updateEntity);
    }

    public async Task<bool> Delete(DeleteWorkEmailCommand command, CancellationToken cts)
    {
        await _deleteValidator.ValidateAndThrowAsync(command, cts);
        var entity = await _dataContext.WorkEmails.Where(c => c.Id == command.Id).FirstAsync();

        _dataContext.WorkEmails.Remove(entity);
        await _dataContext.SaveChangesAsync(cts);

        return true;
    }

    public async Task<bool> AddWorkEmailToTagReportTask(AddWorkEmailToTagReportTaskCommand command, CancellationToken cts)
    {
        await _addToReportTaskValidator.ValidateAndThrowAsync(command, cts);
        
        var reportTask = await _dataContext.TagReportTasks.Where(c => c.Id == command.TagReportTaskId).FirstAsync();
        var email = await _dataContext.WorkEmails.Where(c => c.Id == command.Id).FirstAsync();
        
        reportTask.WorkEmails.Add(email);
        await _dataContext.SaveChangesAsync(cts);

        return true;
        
    }
}