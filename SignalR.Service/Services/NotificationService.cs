using AutoMapper;
using SignalR.Core.DTOs.NotificationDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class NotificationService(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : INotificationService
    {
        public async Task CreateAsync(CreateNotificationDto request)
        {
            var value = mapper.Map<Notification>(request);
            value.Status = false;
            value.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            await notificationRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await notificationRepository.GetByIdAsync(id);
            notificationRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultNotificationDto>> GetAllAsync()
        {
            var value = await notificationRepository.GetAllAsync();
            return mapper.Map<List<ResultNotificationDto>>(value);
        }

        public async Task<List<ResultNotificationDto>> GetAllNotificationByFalseAsync()
        {
            var value = await notificationRepository.GetAllNotificationByFalseAsync();
            return mapper.Map<List<ResultNotificationDto>>(value);
        }

        public async Task<GetByIdNotificationDto> GetByIdAsync(int id)
        {
            var value = await notificationRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdNotificationDto>(value);
        }

        public async Task<int> NotificationCountByStatusFalseAsync()
        {
            return await notificationRepository.NotificationCountByStatusFalseAsync();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            notificationRepository.NotificationStatusChangeToFalse(id);
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            notificationRepository.NotificationStatusChangeToTrue(id);
        }

        public async Task UpdateAsync(UpdateNotificationDto request)
        {
            var value = mapper.Map<Notification>(request);
            value.NotificationId = request.NotificationId;
            notificationRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
