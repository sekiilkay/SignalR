using AutoMapper;
using SignalR.Core.DTOs.OrderDtos;
using SignalR.Core.Entities;

namespace SignalR.Service.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
        }
    }
}
