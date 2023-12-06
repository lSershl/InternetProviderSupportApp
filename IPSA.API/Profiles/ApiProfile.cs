using AutoMapper;
using IPSA.Models;
using IPSA.API.Dtos;

namespace IPSA.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile() 
        {
            // Source -> Target
            CreateMap<AbonentCreateDto, Abonent>();
        }
    }
}
