using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IReservationManager
    {
        Task<BasePagingDto<ReservationDto>> GetYourReservation(int storeId, int currentPage, int pageSize);

        Task<List<ReservationDetailDto>> GetShowDetailYourReservation(int Id);
    }
}
