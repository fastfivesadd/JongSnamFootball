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
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<FieldModel, FieldDto>()
                .ForMember(fd => fd.NameStore, map => map.MapFrom(fm => fm.StoreModel.Name))
               .ForMember(fd => fd.Status, map => map.MapFrom(fm => fm.StoreModel.Status));

            CreateMap<FieldModel, FieldByIdFieldDto>()
                .ForMember(fd => fd.Percentage, map => map.MapFrom(fm => fm.DiscountModel.Percentage));

            CreateMap<FieldModel, FieldRequest>();

            CreateMap<FieldRequest, FieldModel>();


            CreateMap<UpdateFieldRequest, FieldModel>();


            

        }

    }
}
