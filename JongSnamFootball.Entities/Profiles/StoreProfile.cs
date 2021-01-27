using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreModel, StoreDto>();

            CreateMap<StoreModel, YourStore>();

            CreateMap<FieldModel, FieldDto>();

            CreateMap<FieldModel, ListFieldByIdFieldDto>();

            
        }
    }
}
