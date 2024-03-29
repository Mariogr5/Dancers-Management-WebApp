﻿using AutoMapper;
using ptt_api.Entities;
using ptt_api.Models;

namespace ptt_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DanceClub, DanceClubDto>()
                .ForMember(a => a.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(a => a.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(a => a.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
            CreateMap<CreateDanceClubDto, DanceClub>()
                .ForMember(a => a.Address, c => c.MapFrom(dto => new Address()
                {
                    City = dto.City,
                    PostalCode = dto.PostalCode,
                    Street = dto.Street
                }));
            
            CreateMap<Dancer, DancerDto>()
                .ForMember(a => a.DanceClubName, c => c.MapFrom(s => s.DancerClub.Name));

            CreateMap<CreateDancerDto, Dancer>();

            CreateMap<CreateDanceEventDto, DanceEvent>();
            CreateMap<DanceEvent, DanceEventDto>();

            CreateMap<CreateDancePairDto, DancePair>();
            CreateMap<CreateCategoryDto, DanceCompetitionCategory>();
            CreateMap<DanceCompetitionCategory, DanceCompetitionCategoryDto>();
            CreateMap<DancePair, DancePairDto>();
        }
    }
}
