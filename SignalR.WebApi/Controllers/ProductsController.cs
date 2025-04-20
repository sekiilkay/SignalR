using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.ProductDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;
using SignalR.Repository.Context;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var value = await productService.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            var value = await productService.ProductCountAsync();
            return Ok(value);
        }

        [HttpGet("TotalPriceByDrinkCategory")]
        public async Task<IActionResult> TotalPriceByDrinkCategory()
        {
            var value = await productService.TotalPriceByDrinkCategoryAsync();
            return Ok(value);
        }

        [HttpGet("TotalPriceBySaladCategory")]
        public async Task<IActionResult> TotalPriceBySaladCategory()
        {
            var value = await productService.TotalPriceBySaladCategoryAsync();
            return Ok(value);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public async Task<IActionResult> ProductNameByMaxPrice()
        {
            var value = await productService.ProductNameByMaxPriceAsync();
            return Ok(value);
        }

        [HttpGet("ProductNameByMinPrice")]
        public async Task<IActionResult> ProductNameByMinPrice()
        {
            var value = await productService.ProductNameByMinPriceAsync();
            return Ok(value);
        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public async Task<IActionResult> ProductAvgPriceByHamburger()
        {
            var value = await productService.ProductAvgPriceByHamburgerAsync();
            return Ok(value);
        }

        [HttpGet("ProductCountByHamburger")]
        public async Task<IActionResult> ProductCountByHamburger()
        {
            var value = await productService.ProductCountByCategoryNameHamburgerAsync();
            return Ok(value);
        }

        [HttpGet("ProductCountByDrink")]
        public async Task<IActionResult> ProductCountByDrink()
        {
            var value = await productService.ProductCountByCategoryNameDrinkAsync();
            return Ok(value);
        }

        [HttpGet("ProductPriceAvg")]
        public async Task<IActionResult> ProductPriceAvg()
        {
            var value = await productService.ProductPriceAvgAsync();
            return Ok(value);
        }

        [HttpGet("ProductPriceBySteakBurger")]
        public async Task<IActionResult> ProductPriceBySteakBurger()
        {
            var value = await productService.ProductPriceBySteakBurgerAsync();
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var value = await productService.GetProductsWithCategoriesAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto request)
        {
            await productService.CreateAsync(request);
            return Ok("Ürün Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteAsync(id);
            return Ok("Ürün Bilgisi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await productService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto request)
        {
            await productService.UpdateAsync(request);
            return Ok("Ürün Bilgisi Başarıyla Güncellendi");
        }

        [HttpGet("GetLast9Products")]
        public async Task<IActionResult> GetLast9Products()
        {
            var value = await productService.GetLast9ProductsAsync();
            return Ok(value);
        }

        [HttpGet("ProductStatusChangeToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            productService.ProductStatusChangeToTrue(id);
            return Ok();
        }

        [HttpGet("ProductStatusChangeToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            productService.ProductStatusChangeToFalse(id);
            return Ok();
        }
    }
}