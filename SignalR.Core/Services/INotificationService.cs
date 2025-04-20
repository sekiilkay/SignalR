using SignalR.Core.DTOs.NotificationDtos;

namespace SignalR.Core.Services
{
    public interface INotificationService
    {
        Task<List<ResultNotificationDto>> GetAllAsync();
        Task<GetByIdNotificationDto> GetByIdAsync(int id);
        Task CreateAsync(CreateNotificationDto request);
        Task UpdateAsync(UpdateNotificationDto request);
        Task DeleteAsync(int id);

        Task<int> NotificationCountByStatusFalseAsync();
        Task<List<ResultNotificationDto>> GetAllNotificationByFalseAsync();
        void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);
    }
}
