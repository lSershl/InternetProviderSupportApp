using AutoMapper;
using IPSA.Models;
using IPSA.Shared.Dtos;

namespace IPSA.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile() 
        {
            // Source -> Target
            CreateMap<AbonentCreateDto, Abonent>();
            CreateMap<PaymentDto, Payment>();
            CreateMap<AbonPageCommentDto, AbonPageComment>();
            CreateMap<AbonentRequestDto, AbonentRequest>();
        }
    }
}
