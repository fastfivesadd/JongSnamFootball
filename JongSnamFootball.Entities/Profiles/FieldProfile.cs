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
                .ForMember(fd => fd.StoreName, map => map.MapFrom(fm => fm.StoreModel.Name))
               .ForMember(fd => fd.IsOpen, map => map.MapFrom(fm => fm.StoreModel.IsOpen));

            CreateMap<FieldModel, FieldDetailDto>();

            CreateMap<FieldModel, FieldRequest>();

            CreateMap<FieldRequest, FieldModel>();


            CreateMap<UpdateFieldRequest, FieldModel>();




        }

    }
}
