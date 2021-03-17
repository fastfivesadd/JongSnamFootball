using System.Collections.Generic;
using System.Threading.Tasks;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T model);

        Task<IEnumerable<T>> CreateRangeAsync(IEnumerable<T> model);

        T Updete(T model);

        void Delete(T model);
    }
}
