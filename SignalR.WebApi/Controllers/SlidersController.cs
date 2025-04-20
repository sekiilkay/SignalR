using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.SliderDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SlidersController(ISliderService sliderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var value = await sliderService.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider([FromBody] CreateSliderDto request)
        {
            await sliderService.CreateAsync(request);
            return Ok("Öne Çıkan Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await sliderService.DeleteAsync(id);
            return Ok("Öne Çıkan Bilgisi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(int id)
        {
            var value = await sliderService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider([FromBody] UpdateSliderDto request)
        {
            await sliderService.UpdateAsync(request);
            return Ok("Öne Çıkan Alan Bilgisi Başarıyla Güncellendi");
        }
    }
}