using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.TestimonialDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService testimonialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var value = await testimonialService.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialDto request)
        {
            await testimonialService.CreateAsync(request);
            return Ok("Müşteri Yorum Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await testimonialService.DeleteAsync(id);
            return Ok("Müşteri Yorum Bilgisi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await testimonialService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialDto request)
        {
            await testimonialService.UpdateAsync(request);
            return Ok("Müşteri Yorum Bilgisi Başarıyla Güncellendi");
        }
    }
}
