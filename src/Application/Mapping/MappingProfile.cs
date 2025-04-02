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
            CreateMap<UserPostPutDto, User>().ForMember(dest => dest.Phone, opt => opt.MapFrom(src =>
            string.IsNullOrEmpty(src.Number) ? null : new Phone { Number = src.Number }))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;


            /* dest => dest.PhoneNumber: This is the target (UserDto.PhoneNumber).
            	opt => opt.MapFrom(...): We’re telling AutoMapper where to get the value from.
        	    src => src.Phone != null ? src.Phone.Number : string.Empty:
        	    It checks if the Phone object in the User is not null.
        	    If it exists, it takes the Number property.
        	    If it’s null, it sets PhoneNumber to an empty string to avoid null reference exceptions. */

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone != null ? src.Phone.Number : string.Empty));
        }
    }
}
