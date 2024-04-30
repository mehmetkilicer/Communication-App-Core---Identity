using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Communication_App_Core.ViewComponents
{
    public class _LayoutSidebarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _LayoutSidebarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageUrl;
            ViewBag.v1 = $"{values.Name} {values.Surname}";


            return View();
        }
    }
}
