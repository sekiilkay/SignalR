using AutoMapper;
using SignalR.Core.DTOs.MoneyCaseDtos;
using SignalR.Core.Entities;

namespace SignalR.Service.Mapping
{
    public class MoneyCaseMapping : Profile
    {
        public MoneyCaseMapping()
        {
            CreateMap<MoneyCase, CreateMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase, ResultMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase, GetByIdMoneyCaseDto>().ReverseMap();
            CreateMap<MoneyCase, UpdateMoneyCaseDto>().ReverseMap();
        }
    }
}
