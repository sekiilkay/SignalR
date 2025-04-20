using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.SocialMediaDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SocialMediasController(ISocialMediaService socialMediaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var value = await socialMediaService.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaDto request)
        {
            await socialMediaService.CreateAsync(request);
            return Ok("Sosyal Medya Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await socialMediaService.DeleteAsync(id);
            return Ok("Sosyal Medya Bilgisi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await socialMediaService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaDto request)
        {
            await socialMediaService.UpdateAsync(request);
            return Ok("Sosyal Medya Bilgisi Başarıyla Güncellendi");
        }
    }
}