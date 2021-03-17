using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Entities.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewRequest, ReviewModel>();
            CreateMap<ReviewModel, ReviewDto>()
            .ForMember(cd => cd.Name, map => map.MapFrom(cm => $"{cm.UserModel.FirstName} {cm.UserModel.LastName}"));

        }
    }
}
