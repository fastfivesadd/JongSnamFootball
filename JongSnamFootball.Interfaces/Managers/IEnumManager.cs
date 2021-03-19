using System.Collections.Generic;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Interfaces.Managers
{
    public interface IEnumManager
    {
        Task<List<EnumDto>> GetEnum(string enumName, int id);
    }
}
