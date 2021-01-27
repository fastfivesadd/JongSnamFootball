using System;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace JongSnamFootball.Repositories
{
    public abstract class BaseRepository<T> : BaseLogger, IRepository<T> where T : class
    {
        protected readonly RepoDbContext _dbContext;
        public BaseRepository(ILogger logger, RepoDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }
        public T Create(T model)
        {
            throw new NotImplementedException();
        }

        public void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public T Updete(T model)
        {
            throw new NotImplementedException();
        }
    }
}
