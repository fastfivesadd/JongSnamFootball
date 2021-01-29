using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Entities.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationModel, ReservationDto>()
                .ForMember(rm => rm.NameUser, map => map.MapFrom(rd => $"{rd.UserMemberModel.FirstName} {rd.UserMemberModel.LastName}"))
               .ForMember(rm => rm.TelePhone, map => map.MapFrom(rd => rd.UserMemberModel.TelePhone));

            CreateMap<ReservationModel, DetailReservationDto>()
               .ForMember(rm => rm.NameUser, map => map.MapFrom(drd => $"{drd.UserMemberModel.FirstName} {drd.UserMemberModel.LastName}"))
               .ForMember(rm => rm.TelePhone, map => map.MapFrom(drd => drd.UserMemberModel.TelePhone))
               .ForMember(rm => rm.NameField, map => map.MapFrom(drd => drd.FieldModel.Name))
               .ForMember(rm => rm.PriceField, map => map.MapFrom(drd => drd.FieldModel.Price))
               .ForMember(rm => rm.StatusAmount, map => map.MapFrom(drd => drd.PaymentModel.StatusAmount))
               .ForMember(rm => rm.StatusPayment, map => map.MapFrom(drd => drd.PaymentModel.Status))
               .ForMember(rm => rm.AmountPayment, map => map.MapFrom(drd => drd.PaymentModel.Amount));


        }
    }
}
