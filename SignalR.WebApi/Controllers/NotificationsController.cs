using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.NotificationDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationsController(INotificationService notificationService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> NotificationList()
        {
            var values = await notificationService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public async Task<IActionResult> NotificationCountByStatusFalse()
        {
            var value = await notificationService.NotificationCountByStatusFalseAsync();
            return Ok(value);
        }

        [HttpGet("GetAllNotificationByFalse")]
        public async Task<IActionResult> GetAllNotificationByFalse()
        {
            var value = await notificationService.GetAllNotificationByFalseAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDto request)
        {
            await notificationService.CreateAsync(request);
            return Ok("Ekleme İşlemi Başarıyla Yapıldı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await notificationService.DeleteAsync(id);
            return Ok("Bildirim Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var value = await notificationService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification([FromBody] UpdateNotificationDto request)
        {
            await notificationService.UpdateAsync(request);
            return Ok("Güncelleme İşlemi Başarıyla Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            notificationService.NotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            notificationService.NotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }
    }
}