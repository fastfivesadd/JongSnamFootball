using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IReservationManager
    {
        Task<BasePagingDto<ReservationDto>> GetYourReservation(int userId, int currentPage, int pageSize);

        Task<BasePagingDto<GrahpDto>> GraphMonthReservation(int userId, int month, int currentPage, int pageSize);

        Task<BasePagingDto<GrahpDto>> GraphYearReservation(int userId, int year, int currentPage, int pageSize);

        Task<BasePagingDto<ReservationDto>> GetReservationBySearch(int userId, SearchReservationRequest request, int currentPage, int pageSize);

        Task<ReservationDetailDto> GetShowDetailYourReservation(int Id);

        Task<bool> UpdateApprovalStatus(int id, ReservationApprovalRequest request);

        Task<bool> CreateReservation(ReservationRequest request);

        Task<bool> DeleteReservation(int id);
    }
}
