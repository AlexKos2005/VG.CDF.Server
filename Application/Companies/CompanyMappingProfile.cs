﻿using AutoMapper;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Companies;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<CreateCompanyCommand, Company>().ReverseMap();
        CreateMap<DeleteCompanyCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateCompanyCommand, Company>().ReverseMap();
        
    }
}