using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentModel, CommentDto>()
                  .ForMember(cd => cd.Name, map => map.MapFrom(cm => $"{cm.UserModel.FirstName} {cm.UserModel.LastName}"));

        }
    }
}