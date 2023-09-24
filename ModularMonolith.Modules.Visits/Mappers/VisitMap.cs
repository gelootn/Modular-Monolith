﻿using AutoMapper;
using ModularMonolith.Entities;
using ModularMonolith.Modules.Visits.Database.Repositories.Filters;
using ModularMonolith.Modules.Visits.Dtos;
using ModularMonolith.Modules.Visits.Queries.Visits.GetVisits;

namespace ModularMonolith.Modules.Visits.Mappers;

public class VisitMap : Profile
{
    public VisitMap()
    {
        CreateMap<Visit, VisitDetail>()
            .ForMember(x => x.VisitorName, cfg => cfg.MapFrom(x => x.Visitor.Name))
            .ForMember(x => x.VisitorEmail, cfg => cfg.MapFrom(x => x.Visitor.Email))
            .ForMember(x => x.VisitorCompany, cfg => cfg.MapFrom(x => x.Visitor.Company))
            .ForMember(x=> x.VisitingCompany, cfg => cfg.MapFrom(x=> x.Company.Name))
            .ForMember(x=> x.VisitingEmployee, cfg => cfg.MapFrom(x=> x.Employee.Name))
            .ForMember(x=> x.StartTime, cfg => cfg.MapFrom(x=> x.Start))
            .ForMember(x => x.EndTime, cfg => cfg.MapFrom(x=> x.Stop))
            ;

        CreateMap<GetVisitsQuery, VisitFilter>();
    }
}