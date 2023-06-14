using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Languages.Commands;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Parameters;

public class LanguageMappingProfile : Profile
{
    public LanguageMappingProfile()
    {
        CreateMap<Language, LanguageDto>().ReverseMap();
        CreateMap<CreateLanguageCommand, EntityBase>().ReverseMap();
        CreateMap<DeleteLanguageCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateLanguageCommand, EntityBase>().ReverseMap();
    }
}