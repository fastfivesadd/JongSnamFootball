using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<ReservationModel>
    {
        Task<List<ReservationModel>> GetAll();

        Task<List<ReservationModel>> GetYourReservation(int? storeID);

        Task<List<ReservationModel>> GetShowDetailYourReservation(int? Id);

        Task<ReservationModel> GetReservatioById(int id);
    }
}
