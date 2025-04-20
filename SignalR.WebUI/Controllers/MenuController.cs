using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.MenuTableDtos;
using SignalR.Core.Entities;
using SignalR.WebUI.Dtos.BasketDtos;
using SignalR.WebUI.Dtos.ProductDtos;
using System.Net.Http;
using System.Text;

namespace SignalR.WebUI.Controllers
{
    public class MenuController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz
                            // TempData["x"] = id; // Eğer bunu kullanıyorsanız

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7077/Products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }


        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {
            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0 geliyor.");
            }

            CreateBasketDto createBasketDto = new CreateBasketDto
            {
                ProductId = id,
                MenuTableId = menuTableId // Gelen MenuTableID burada kullanılıyor
            };

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7077/Baskets", stringContent);

            var client2 = httpClientFactory.CreateClient();
            //var jsonData2 = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client2.GetAsync("https://localhost:7077/MenuTables/ChangeMenuTableStatusToTrue?id=" + menuTableId);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDto);
        }

        public async Task<IActionResult> ChooseTable()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7077/MenuTables/GetMenuTableByStatusFalse");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var menuTables = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);

            return View(menuTables);
        }
    }
}