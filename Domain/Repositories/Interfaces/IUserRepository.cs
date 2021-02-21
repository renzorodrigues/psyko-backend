using System.Collections.Generic;
using System.Threading.Tasks;
using CCAU.Domain.Entities;

namespace CCAU.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
         Task<List<User>> GetUsers();
         Task<User> GetUserById(int id);
         Task<int> PostUser(User user);
    }
}