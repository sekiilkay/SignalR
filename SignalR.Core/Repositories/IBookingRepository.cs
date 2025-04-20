using SignalR.Core.Entities;

namespace SignalR.Core.Repositories
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);
        Task<int> BookingCountAsync();
    }
}
