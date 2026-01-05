using AutoMapper;
using eCommers.Core.DTO;
using eCommers.Core.Entities;
using Microsoft.Extensions.Options;

namespace eCommers.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser,AuthenticationResponse>()
                .ForMember(dest => dest.UserId,options => options.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Email,options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.PersonName,options => options.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender,options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Success,options => options.Ignore())
                .ForMember(dest => dest.Token,options => options.Ignore());


            CreateMap<RegisterRequest,ApplicationUser>()
                .ForMember(dest => dest.Email,options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password,options => options.MapFrom(src => src.Password))
                .ForMember(dest => dest.PersonName,options => options.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Gender,options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.UserId,options => options.Ignore());
        }
    }
}