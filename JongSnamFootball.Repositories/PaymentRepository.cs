using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JongSnamFootball.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentModel>, IPaymentRepository
    {
        public PaymentRepository(RepositoryDbContext context) : base(context)
        {

        }

        public async Task<List<PaymentModel>> GetAll()
        {
            var result = await _dbContext.Payment.AsNoTracking().ToListAsync();
            return result;
        }
    }
}
