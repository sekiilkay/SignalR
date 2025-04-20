using SignalR.Core.DTOs.BookingDtos;

namespace SignalR.Core.Services
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllAsync();
        Task<GetByIdBookingDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBookingDto request);
        Task UpdateAsync(UpdateBookingDto request);
        Task DeleteAsync(int id);

        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);
        Task<int> BookingCountAsync();
    }
}
