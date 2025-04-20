using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.AboutDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AboutsController(IAboutService aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var value = await aboutService.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await aboutService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody]CreateAboutDto request)
        {
            await aboutService.CreateAsync(request);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await aboutService.DeleteAsync(id);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody]UpdateAboutDto request)
        {
            await aboutService.UpdateAsync(request);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Güncellendi");
        }
    }
}