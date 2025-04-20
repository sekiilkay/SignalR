using AutoMapper;
using SignalR.Core.DTOs.BookingDtos;
using SignalR.Core.Entities;
using SignalR.Core.Repositories;
using SignalR.Core.Services;
using SignalR.Core.UnitOfWork;

namespace SignalR.Service.Services
{
    public class BookingService(
        IBookingRepository bookingRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IBookingService
    {
        public async Task<int> BookingCountAsync()
        {
            return await bookingRepository.BookingCountAsync();
        }

        public void BookingStatusApproved(int id)
        {
            bookingRepository.BookingStatusApproved(id);
        }

        public void BookingStatusCancelled(int id)
        {
            bookingRepository.BookingStatusCancelled(id);
        }

        public async Task CreateAsync(CreateBookingDto request)
        {
            var value = mapper.Map<Booking>(request);
            value.Description = "Rezervasyon Alındı";
            await bookingRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await bookingRepository.GetByIdAsync(id);
            bookingRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultBookingDto>> GetAllAsync()
        {
            var value = await bookingRepository.GetAllAsync();
            return mapper.Map<List<ResultBookingDto>>(value);
        }

        public async Task<GetByIdBookingDto> GetByIdAsync(int id)
        {
            var value = await bookingRepository.GetByIdAsync(id);
            return mapper.Map<GetByIdBookingDto>(value);
        }

        public async Task UpdateAsync(UpdateBookingDto request)
        {
            var value = mapper.Map<Booking>(request);
            value.BookingId = request.BookingId;
            bookingRepository.Update(value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
