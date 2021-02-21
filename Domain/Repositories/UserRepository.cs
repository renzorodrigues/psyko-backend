using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCAU.Data;
using CCAU.Domain.Entities;
using CCAU.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CCAU.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        public async Task<int> PostUser(User user)
        {
            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            return user.Id;            
        }
    }
}