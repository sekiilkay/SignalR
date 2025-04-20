using AutoMapper;
using SignalR.Core.DTOs.BasketDtos;
using SignalR.Core.Entities;

namespace SignalR.Service.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, GetByIdBasketDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketListWithProducts>().ReverseMap();
        }
    }
}
