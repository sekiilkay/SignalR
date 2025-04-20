using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.Entities;
using SignalR.WebUI.Dtos.IdentityDtos;

namespace SignalR.WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Surname = values.Surname;
            userEditDto.Name = values.Name;
            userEditDto.UserName = values.UserName;
            userEditDto.Mail = values.Email;
            userEditDto.ImageUrl = values.ImageUrl;
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                user.ImageUrl = userEditDto.ImageUrl;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Statistic");
            }
            return View();
        }
    }
}