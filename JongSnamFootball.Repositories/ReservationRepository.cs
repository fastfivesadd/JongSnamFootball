using System.Collections.Generic;
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
            var result = await _dbContext.Reservation.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
