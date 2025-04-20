using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Core.DTOs.MoneyCaseDtos;
using SignalR.Core.Entities;
using SignalR.WebUI.Dtos.BasketDtos;
using System.Net.Http;
using System.Text;

namespace SignalR.WebUI.Controllers
{

    [AllowAnonymous]
    public class BasketController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7077/Baskets/BasketListByMenuTableWithProductName?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                ViewBag.totalPrice = values.Sum(x => x.Price) + (values.Sum(x => x.Price) / 100 * 10);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            int menuTableId = int.Parse(TempData["id"].ToString());
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($" https://localhost:7077/Baskets/{id}");
       
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Basket", new { id = menuTableId });
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Index(decimal totalPrice)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7077/MoneyCases/1");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var moneyCase = JsonConvert.DeserializeObject<MoneyCase>(jsonData);

                moneyCase.TotalAmount += totalPrice;

                UpdateMoneyCaseDto request = new UpdateMoneyCaseDto
                {
                    MoneyCaseId = moneyCase.MoneyCaseId,
                    TotalAmount = moneyCase.TotalAmount
                };

                var response = await client.PutAsync("https://localhost:7077/MoneyCases", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Default");

                }
            }
            return View();
        }
    }
}