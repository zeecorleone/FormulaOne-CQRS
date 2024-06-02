

using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Domain.Entities;

namespace FormulaOne.Application.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateDriverAchievementRequest, Achievement>()
            .ForMember(dest => dest.RaceWins,
            opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.CreatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow));

        CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(dest => dest.RaceWins,
            opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow));

        
        
        
        CreateMap<CreateDriverRequest, Driver>()
            .ForMember(dest => dest.Status,
            opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.CreatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow));

        CreateMap<UpdateDriverRequest, Driver>()
            .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(dest => DateTime.UtcNow));
    }
}
