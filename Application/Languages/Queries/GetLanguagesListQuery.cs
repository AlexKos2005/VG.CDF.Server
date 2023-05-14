using System;
using System.Collections.Generic;
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

namespace VG.CDF.Server.Application.Languages.Queries;

public class GetLanguagesListQuery: IRequest<IEnumerable<LanguageDto>>
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;
    public string? Acronym { get; set; } = null;
    
    public class GetLanguagesListQueryHandler : IRequestHandler<GetLanguagesListQuery,IEnumerable<LanguageDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetLanguagesListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LanguageDto>> Handle(GetLanguagesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Language> languageQuery = _dataContext.Set<Language>();

            if (request.Id != null)
                languageQuery = languageQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                languageQuery = languageQuery.Where(c => c.ExternalId == request.ExternalId);
            if (!string.IsNullOrEmpty(request.Acronym))
                languageQuery = languageQuery.Where(c => c.Acronym.ToLower() == request.Acronym.ToLower());
            
            var languages = await languageQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<LanguageDto>>(languages);

        }
    }
}