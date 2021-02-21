using System.Collections.Generic;
using System.Threading.Tasks;
using CCAU.Domain.DTOs;
using CCAU.Domain.Entities;
using CCAU.Helpers.Utils;

namespace CCAU.Domain.Services.Interfaces
{
    public interface IUserService
    {
         Task<List<User>> GetUsers();
         Task<ResponseContent> GetUserById(int id);
         Task<int> PostUser(UserForRequest user);
    }
}