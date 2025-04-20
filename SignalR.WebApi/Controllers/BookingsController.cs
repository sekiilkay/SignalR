using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.BookingDtos;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController(IBookingService bookingService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var value = await bookingService.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody]CreateBookingDto request)
        {
            await bookingService.CreateAsync(request);
            return Ok("Rezervasyon Başarıyla Yapıldı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await bookingService.DeleteAsync(id);
            return Ok("Rezervasyon Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody]UpdateBookingDto request)
        {
            await bookingService.UpdateAsync(request);
            return Ok("Rezervasyon Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var value = await bookingService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingCount")]
        public async Task<IActionResult> BookingCount()
        {
            var value = await bookingService.BookingCountAsync();
            return Ok(value);
        }
    }
}
