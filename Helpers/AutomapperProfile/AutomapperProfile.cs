using AutoMapper;
using CCAU.Domain.DTOs;
using CCAU.Domain.Entities;

namespace CCAU.Helpers.AutomapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserForRequest, User>();
        }
    }
}