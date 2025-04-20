using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.CategoryDtos;
using SignalR.Core.Services;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await categoryService.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            var value = await categoryService.CategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            var value = await categoryService.ActiveCategoryCountAsync();
            return Ok(value);
        }

        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            var value = await categoryService.PassiveCategoryCountAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            await categoryService.CreateAsync(request);
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await categoryService.DeleteAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCateegory(int id)
        {
            var value = await categoryService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto request)
        {
            await categoryService.UpdateAsync(request);
            return Ok("Kategori Başarıyla Güncellendi");
        }

        [HttpGet("CategoryStatusChangeToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            categoryService.CategoryStatusChangeToTrue(id);
            return Ok();
        }

        [HttpGet("CategoryStatusChangeToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            categoryService.CategoryStatusChangeToFalse(id);
            return Ok();
        }
    }
}
