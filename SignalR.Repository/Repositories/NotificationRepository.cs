using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class NotificationRepository(SignalRContext context) : GenericRepository<Notification>(context), INotificationRepository
    {
        public async Task<List<Notification>> GetAllNotificationByFalseAsync()
        {
            return await context.Notifications
                .Where(x => x.Status == false)
                .ToListAsync();
        }

        public async Task<int> NotificationCountByStatusFalseAsync()
        {
            return await context.Notifications
                .Where(x => x.Status == false)
                .CountAsync();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = false;
            Context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.Status = true;
            Context.SaveChanges();
        }
    }
}
