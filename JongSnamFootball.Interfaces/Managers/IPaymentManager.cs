using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IPaymentManager
    {

        Task<List<PaymentDto>> GetPaymentByReservationId(int reservationId);

        Task<PaymentDto> GetPaymentById(int id);

        Task<bool> AddPayment(PaymentRequest request);

        Task<bool> UpdatePayment(int id, UpdatePaymentRequest request);
    }
}
