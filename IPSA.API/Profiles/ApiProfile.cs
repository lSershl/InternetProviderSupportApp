using AutoMapper;
using IPSA.Models;
using IPSA.Shared.Dtos;

namespace IPSA.API.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile() 
        {
            // Dto -> Model
            CreateMap<AbonentCreateDto, Abonent>();
            CreateMap<PaymentDto, Payment>();
            CreateMap<AbonPageCommentDto, AbonPageComment>();
            CreateMap<AbonentRequestDto, AbonentRequest>();
            CreateMap<ConnectedTariffDto, ConnectedTariff>();

            // Model -> Dto
            CreateMap<Abonent, AbonentReadDto>();
            CreateMap<City, CityReadDto>();
            CreateMap<Street, StreetReadDto>();
            CreateMap<FeeWithdraw, FeeWithdrawRecordDto>();
            CreateMap<Payment, PaymentDto>();
        }
    }
}
