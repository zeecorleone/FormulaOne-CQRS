

using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Domain.Entities;

namespace FormulaOne.Application.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Achievement, DriverAchievementResponse>()
            .ForMember(dest => dest.Wins,
            opt => opt.MapFrom(src => src.RaceWins));

        CreateMap<Driver, GetDriverResponse>()
            .ForMember(dest => dest.FullName,
            opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.DriverId,
            opt => opt.MapFrom(src => src.Id));
    }
}
