using System.Linq;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Entities.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationModel, ReservationDto>()
                .ForMember(rm => rm.UserName, map => map.MapFrom(rd => $"{rd.UserModel.FirstName} {rd.UserModel.LastName}"))
               .ForMember(rm => rm.ContactMobile, map => map.MapFrom(rd => rd.UserModel.ContactMobile))
               .ForMember(rm => rm.StoreName, map => map.MapFrom(rd => rd.StoreModel.Name));

            CreateMap<ReservationModel, ReservationDetailDto>()
               .ForMember(rm => rm.UserName, map => map.MapFrom(drd => $"{drd.UserModel.FirstName} {drd.UserModel.LastName}"))
               .ForMember(rm => rm.ContactMobile, map => map.MapFrom(drd => drd.UserModel.ContactMobile))
               .ForMember(rm => rm.FieldName, map => map.MapFrom(drd => drd.FieldModel.Name))
               .ForMember(rm => rm.PricePerHour, map => map.MapFrom(drd => drd.FieldModel.Price))
               .ForMember(rm => rm.AmountForPay, map => map.MapFrom(drd => drd.PaymentModel.Sum(s => s.Amount)))
               .ForMember(rm => rm.StoreName, map => map.MapFrom(drd => drd.StoreModel.Name));

            CreateMap<ReservationRequest, ReservationModel>();
        }
    }
}
