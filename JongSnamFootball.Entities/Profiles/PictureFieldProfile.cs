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
    public class PictureFieldProfile : Profile
    {
        public PictureFieldProfile()
        {
            CreateMap<ImageFieldRequest, ImageFieldModel>();

            CreateMap<ImageFieldModel, ImageFieldDto>();
        }
    }
}
