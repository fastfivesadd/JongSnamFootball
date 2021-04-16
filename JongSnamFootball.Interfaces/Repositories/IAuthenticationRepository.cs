using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Models;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<UserModel> GetUser(string user, string passwordEncrypted);
    }
}
