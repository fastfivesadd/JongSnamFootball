using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IPictureFieldRepository : IRepository<PictureFieldModel>
    {
        Task<List<PictureFieldModel>> GetAll();
    }
}
