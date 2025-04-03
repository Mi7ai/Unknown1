// Application/Mapping/MappingProfile.cs
using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserPostPutDto, User>()
            .ForMember(dest => dest.Phone, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone != null ? src.Phone.Number : string.Empty));

            CreateMap<PhoneDto, Phone>();
        }
    }
}
