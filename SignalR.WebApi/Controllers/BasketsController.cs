using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.BasketDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketsController(IBasketService basketService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasketByMenuTableId(int id)
        {
            var value = await basketService.GetBasketByMenuTableNumberAsync(id);
            return Ok(value);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public async Task<IActionResult> BasketListByMenuTableWithProductName(int id)
        {
            var value = await basketService.GetBasketByMenuTableWithProductNameAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketDto request)
        {
            await basketService.CreateAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            await basketService.DeleteAsync(id);
            return Ok("Sepetteki Seçilen Ürün Başarıyla Silindi");
        }

        [HttpDelete("DeleteBasketByMenuTableId/{menuTableId:int}")] 
        public async Task<IActionResult> DeleteBasketByMenuTableId(int menuTableId)
        {
            await basketService.DeleteBasketByMenuTableIdAsync(menuTableId);
            return Ok("Sepetteki Ürünler Başarıyla Silindi");
        }
    }
}