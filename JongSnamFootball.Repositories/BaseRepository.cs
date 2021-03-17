using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Interfaces.Repositories;

namespace JongSnamFootball.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly RepositoryDbContext _dbContext;

        public BaseRepository(RepositoryDbContext dbContext) : base()
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T model)
        {
            await _dbContext.Set<T>().AddAsync(model);
            return model;
        } 

        public async Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> model)
        {
            await _dbContext.Set<T>().AddRangeAsync(model);
            return model;
        }

        public void Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
        }

        public T Updete(T model)
        {
            return _dbContext.Set<T>().Update(model).Entity;
        }
    }
}
