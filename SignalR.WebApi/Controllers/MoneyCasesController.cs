using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.MoneyCaseDtos;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoneyCasesController(IMoneyCaseService moneyCaseService) : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> TotalMoneyCaseAmount()
        {
            var value = await moneyCaseService.TotalMoneyCaseAmountAsync();
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMoneyCaseAmount([FromBody] UpdateMoneyCaseDto request)
        {
            await moneyCaseService.UpdateAsync(request);
            return Ok("Kasa Tutarı Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMoneyCase()
        {
            var value = await moneyCaseService.GetByIdAsync(1);
            return Ok(value);
        }
    }
}
