using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<int> NotificationCountByStatusFalseAsync();
        Task<List<Notification>> GetAllNotificationByFalseAsync();
        void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);

    }
}
