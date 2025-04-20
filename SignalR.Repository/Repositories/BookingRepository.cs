using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Repository.Context;

namespace SignalR.Repository.Repositories
{
    public class BookingRepository(SignalRContext context) : GenericRepository<Booking>(context), IBookingRepository
    {
        public async Task<int> BookingCountAsync()
        {
            return await context.Bookings
                .CountAsync();
        }

        public void BookingStatusApproved(int id)
        {
            var value = context.Bookings.Find(id);
            value.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            var value = context.Bookings.Find(id);
            value.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
