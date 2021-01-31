using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class ReservationManager : IReservationManager
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationManager(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<BasePagingDto<ReservationDto>> GetYourReservation(int storeId, int currentPage, int pageSize)
        {
            var listStore = await _reservationRepository.GetYourReservation(storeId);

            var listFieldDto = _mapper.Map<List<ReservationDto>>(listStore);

            var result = MakePaging.ReservationDtoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }

        public async Task<List<ReservationDetailDto>> GetShowDetailYourReservation(int Id)
        {
            var listStore = await _reservationRepository.GetShowDetailYourReservation(Id);

            var result = _mapper.Map<List<ReservationDetailDto>>(listStore);

            return result;
        }

    }
}
