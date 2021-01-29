using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Entities.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreModel, StoreDto>();

            CreateMap<StoreModel, YourStore>();

            CreateMap<StoreRequest, StoreModel>();
        }
    }
}
