using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        public PaymentManager(IMapper mapper, IPaymentRepository paymentRepository, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _repositoryWrapper = repositoryWrapper;
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
