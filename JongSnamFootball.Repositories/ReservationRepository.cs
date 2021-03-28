using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class ReservationRepository : BaseRepository<ReservationModel>, IReservationRepository
    {
        public ReservationRepository(RepositoryDbContext context) : base(context)
        {

        }
        public async Task<List<ReservationModel>> GetReservationBySearch(int userId, SearchReservationRequest request)
        {
            //var result = _dbContext.Reservations.Where(w => w.StoreId == storeId)
            //    .Include(i => i.UserModel).Include(i => i.StoreModel).Where(w => w.StoreModel.OwnerId == ownerId)
            //    .AsNoTracking();

            var result = _dbContext.Reservations.Where(w => w.StoreModel.OwnerId == userId || w.UserId == userId).Include(i => i.UserModel).Include(i => i.StoreModel).AsNoTracking();

            var aa = result.ToList();

            if (request.StartTime != null && request.StopTime != null)
            {
                var startTime = new DateTime(request.StartTime.Year, request.StartTime.Month, request.StartTime.Day,
                    request.StartTime.Hour, request.StartTime.Minute, request.StartTime.Second);

                var stopTime = new DateTime(request.StopTime.Year, request.StopTime.Month, request.StopTime.Day,
                    request.StopTime.Hour, request.StopTime.Minute, request.StopTime.Second);

                result = result.Where(w => w.StartTime >= startTime && w.StopTime <= stopTime).AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                result = result.Where(w => w.UserModel.FirstName.Contains(request.UserName)).AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(request.StoreName))
            {
                result = result.Where(w => w.StoreModel.Name.Contains(request.StoreName)).AsNoTracking();
            }
            return await result.ToListAsync();
        }

        public async Task<List<ReservationModel>> GetYourReservation(int userId)
        {
            return await _dbContext.Reservations.Where(w => w.StoreModel.OwnerId == userId || w.UserId == userId).Include(i => i.UserModel).Include(i => i.StoreModel).AsNoTracking().ToListAsync();
        }

        public async Task<ReservationModel> GetShowDetailYourReservation(int Id)
        {
            return await _dbContext.Reservations.Where(w => w.Id == Id)
                .Include(i => i.UserModel)
                .Include(i => i.StoreModel)
                .Include(i => i.PaymentModel)
                .Include(i => i.FieldModel)
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ReservationModel> GetReservatioById(int id)
        {
            return await _dbContext.Reservations.Where(w => w.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
