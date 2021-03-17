using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class ReservationManager : IReservationManager
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReservationManager(IMapper mapper, IReservationRepository reservationRepository, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<BasePagingDto<ReservationDto>> GetYourReservation(int storeId, int ownerId, int currentPage, int pageSize)
        {
            var listStore = await _reservationRepository.GetYourReservation(storeId, ownerId);

            var listFieldDto = _mapper.Map<List<ReservationDto>>(listStore);

            var result = MakePaging.ReservationDtoToPaging(listFieldDto, currentPage, pageSize);

            return result;
        }

        public async Task<BasePagingDto<ReservationDto>> GetReservationBySearch(int storeId,int ownerId, SearchReservationRequest request, int currentPage, int pageSize)
        {
            var listReservation = await _reservationRepository.GetReservationBySearch(storeId, ownerId, request);
            var lisReservationDto = _mapper.Map<List<ReservationDto>>(listReservation);

            var result = MakePaging.ReservationDtoToPaging(lisReservationDto, currentPage, pageSize);

            return result;
        }

        public async Task<List<ReservationDetailDto>> GetShowDetailYourReservation(int Id)
        {
            var listStore = await _reservationRepository.GetShowDetailYourReservation(Id);

            var result = _mapper.Map<List<ReservationDetailDto>>(listStore);

            return result;
        }

        public async Task<bool> UpdateApprovalStatus(int id ,ReservationApprovalRequest request)
        {
            try
            {
                var reservationModel = await _reservationRepository.GetReservatioById(id);

                reservationModel.ApprovalStatus = request.ApprovalStatus;
                reservationModel.UpdatedDate = DateTime.Now;

                _repositoryWrapper.Reservation.Updete(reservationModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateReservation(ReservationRequest request)
        {
            try
            {
                var reservationModel = _mapper.Map<ReservationModel>(request);

                reservationModel.CreatedDate = DateTime.Now;
                reservationModel.UpdatedDate = DateTime.Now;
                reservationModel.ApprovalStatus = false;

                await _repositoryWrapper.Reservation.CreateAsync(reservationModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteReservation(int id)
        {
            try
            {
                var reservationModel = await _reservationRepository.GetReservatioById(id);
                if (reservationModel == null)
                {
                    return false;
                }
                
                await _repositoryWrapper.BeginTransactionAsync();

                reservationModel.Active = false;

                _repositoryWrapper.Reservation.Updete(reservationModel);
                
                await _repositoryWrapper.SaveAsync();

                await _repositoryWrapper.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _repositoryWrapper.Dispose();
            }
        }


    }
}
