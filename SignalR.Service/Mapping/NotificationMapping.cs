using AutoMapper;
using SignalR.Core.DTOs.NotificationDtos;
using SignalR.Core.Entities;

namespace SignalR.Service.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
        }
    }
}
