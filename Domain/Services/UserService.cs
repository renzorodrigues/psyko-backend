using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CCAU.Domain.DTOs;
using CCAU.Domain.Entities;
using CCAU.Domain.Repositories.Interfaces;
using CCAU.Domain.Services.Interfaces;
using CCAU.Helpers.Utils;

namespace CCAU.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<ResponseContent> GetUserById(int id)
        {
            var result = await this.userRepository.GetUserById(id);

            if (result == null)
                return new ResponseContent() { StatusCode = HttpStatusCode.NotFound };
            else
                return new ResponseContent() { StatusCode = HttpStatusCode.OK, Data = result };
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.userRepository.GetUsers();
        }

        public async Task<int> PostUser(UserForRequest userForRequest)
        {
            var user = this.mapper.Map<User>(userForRequest);
            return await this.userRepository.PostUser(user);
        }
    }
}