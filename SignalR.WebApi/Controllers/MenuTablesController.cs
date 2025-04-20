using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.MenuTableDtos;
using SignalR.Core.Services;
using SignalR.Service.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuTablesController(IMenuTableService menuTableService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> MenuTableList()
        {
            var value = await menuTableService.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("MenuTableCount")]
        public async Task<IActionResult> MenuTableCount()
        {
            var value = await menuTableService.MenuTableCountAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable([FromBody] CreateMenuTableDto request)
        {
            await menuTableService.CreateAsync(request);
            return Ok("Masa Başarılı Bir Şekilde Ekledi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            await menuTableService.DeleteAsync(id);
            return Ok("Masa Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuTable([FromBody] UpdateMenuTableDto request)
        {
            await menuTableService.UpdateAsync(request);
            return Ok("Masa Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuTable(int id)
        {
            var value = await menuTableService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            menuTableService.ChangeMenuTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }

        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            menuTableService.ChangeMenuTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }

        [HttpGet("GetMenuTableByStatusFalse")]
        public async Task<IActionResult> GetMenuTableByStatusFalse()
        {
            var value = await menuTableService.GetMenuTableByStatusFalseAsync();
            return Ok(value);
        }
    }
}
