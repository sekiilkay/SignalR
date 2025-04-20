using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.MessageDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController(IMessageService messageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var values = await messageService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto request)
        {
            await messageService.CreateAsync(request);
            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await messageService.DeleteAsync(id);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageDto request)
        {
            await messageService.UpdateAsync(request);
            return Ok("Mesaj Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var value = await messageService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}