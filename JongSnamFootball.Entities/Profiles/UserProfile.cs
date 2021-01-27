using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.RequestModel;

namespace JongSnamFootball.Entities.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserMemberModel, UserDto>();
            CreateMap<UserRequestDto, UserMemberModel>();
        }
    }
}
