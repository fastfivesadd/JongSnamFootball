using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class ReservationRepository : BaseRepository<ReservationModel>, IReservationRepository
    {
        public ReservationRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<ReservationModel>> GetAll()
        {
            var result = await _dbContext.Reservations.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<List<ReservationModel>> GetYourReservation(int? storeID)
        {
            return await _dbContext.Reservations.Where(w => w.StoreId == storeID).Include(i => i.UserModel).AsNoTracking().ToListAsync();
        }

        public async Task<List<ReservationModel>> GetShowDetailYourReservation(int? Id)
        {
            return await _dbContext.Reservations.Where(w => w.Id == Id)
                .Include(i => i.UserModel)
                .Include(i => i.StoreModel)
                .Include(i => i.PaymentModel)
                .Include(i => i.FieldModel)
                .AsNoTracking().ToListAsync();
        }

        public async Task<ReservationModel> GetReservatioById(int id)
        {
            return await _dbContext.Reservations.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
