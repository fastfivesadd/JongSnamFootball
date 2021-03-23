using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<ReservationModel>
    {
        Task<List<ReservationModel>> GetReservationBySearch(int userId, SearchReservationRequest request);

        Task<List<ReservationModel>> GetYourReservation(int userId);

        Task<List<ReservationModel>> GetShowDetailYourReservation(int Id);

        Task<ReservationModel> GetReservatioById(int id);
    }
}
