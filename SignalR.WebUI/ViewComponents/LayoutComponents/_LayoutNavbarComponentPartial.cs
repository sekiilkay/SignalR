using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Core.Entities;
using System.Security.Claims;

namespace SignalR.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await userManager.FindByIdAsync(userId);
            return View(user);
        }
    }
}
