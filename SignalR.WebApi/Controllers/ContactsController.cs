using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.DTOs.ContactDtos;
using SignalR.Core.Entities;
using SignalR.Core.Services;

namespace SignalR.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var value = await contactService.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await contactService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDto request)
        {
            await contactService.CreateAsync(request);
            return Ok("İletişim Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await contactService.DeleteAsync(id);
            return Ok("İletişim Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactDto request)
        {
            await contactService.UpdateAsync(request);
            return Ok("İletişim Başarılı Bir Şekilde Güncellendi");
        }
    }
}