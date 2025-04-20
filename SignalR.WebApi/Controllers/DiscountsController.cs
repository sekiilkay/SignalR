using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.DiscountDtos;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController(IDiscountService discountService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var value = await discountService.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto request)
        {
            await discountService.CreateAsync(request);
            return Ok("İndirim Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await discountService.DeleteAsync(id);
            return Ok("İndirim Bilgisi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscount(int id)
        {
            var value = await discountService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountDto request)
        {
            await discountService.UpdateAsync(request);
            return Ok("İndirim Bilgisi Başarıyla Güncellendi");
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            discountService.ChangeStatusToTrue(id);
            return Ok("İndirim Aktif Hale Getirildi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            discountService.ChangeStatusToFalse(id);
            return Ok("İndirim Pasif Hale Getirildi");
        }

        [HttpGet("GetListByStatusTrue")]
        public async Task<IActionResult> GetListByStatusTrue()
        {
            var value = await discountService.GetListByStatusTrueAsync();
            return Ok(value);
        }
    }
}
