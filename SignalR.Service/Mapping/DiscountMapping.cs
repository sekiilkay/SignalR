using AutoMapper;
using SignalR.Core.DTOs.DiscountDtos;
using SignalR.Core.Entities;

namespace SignalR.Service.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
        }
    }
}
