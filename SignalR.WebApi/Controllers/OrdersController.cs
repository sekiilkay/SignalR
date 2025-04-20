using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.OrderDtos;
using SignalR.Core.Services;
using SignalR.Service.Services;
using System.Linq.Expressions;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("TotalOrderCount")]
        public async Task<IActionResult> TotalOrderCount()
        {
            var value = await orderService.TotalOrderCountAsync();
            return Ok(value);
        }

        [HttpGet("ActiveOrderCount")]
        public async Task<IActionResult> ActiveOrderCount()
        {
            var value = await orderService.ActiveOrderCountAsync();
            return Ok(value);
        }

        [HttpGet("LastOrderPrice")]
        public async Task<IActionResult> LastOrderPrice()
        {
            var value = await orderService.LastOrderPriceAsync();
            return Ok(value);
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            var value = orderService.TodayTotalPrice();
            return Ok(value);
        }
    }
}