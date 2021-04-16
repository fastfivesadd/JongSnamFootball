using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;

namespace JongSnamFootball.Managers
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IReservationRepository _reservationRepository;
        public PaymentManager(IMapper mapper, IPaymentRepository paymentRepository, IRepositoryWrapper repositoryWrapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _repositoryWrapper = repositoryWrapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<List<PaymentDto>> GetPaymentByReservationId(int reservationId)
        {

            var paymentModel = await _paymentRepository.GetByReservationId(reservationId);

            var PaymentDto = _mapper.Map<List<PaymentDto>>(paymentModel);

            return PaymentDto;

        }
        public async Task<PaymentDto> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetPaymentById(id);
            var result = _mapper.Map<PaymentDto>(payment);
            return result;
        }

        public async Task<bool> AddPayment(PaymentRequest request)
        {
            try
            {
                var paymentModel = _mapper.Map<PaymentModel>(request);

                paymentModel.CreatedDate = DateTime.Now;
                paymentModel.UpdatedDate = DateTime.Now;

                await _repositoryWrapper.Payment.CreateAsync(paymentModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePayment(int id, UpdatePaymentRequest request)
        {
            try
            {
                var paymentModel = await _paymentRepository.GetPaymentById(id);

                var reservationModel = await _reservationRepository.GetReservatioById(paymentModel.ReservationId);

                if (reservationModel.ApprovalStatus)
                {
                    return false;
                }

                paymentModel.Image = request.Image;
                paymentModel.Amount = request.Amount;
                paymentModel.Date = request.Date;
                paymentModel.IsFullAmount = request.IsFullAmount;

                _repositoryWrapper.Payment.Updete(paymentModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
