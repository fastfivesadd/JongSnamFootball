using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Entities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ForMember(rm => rm.Image, map => map.MapFrom(rd => rd.ImageProfile));
            CreateMap<UserRequest, UserModel>();
        }
    }
}
