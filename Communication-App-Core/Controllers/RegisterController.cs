using BusinessLayer.Concrete;
using Communication_App_Core.Models;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Communication_App_Core.Controllers
{
    public class RegisterController : Controller
    {
        ProjeContext context = new ProjeContext();

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.Values = values;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterViewModel p)
        {
            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.Values = values;

            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Email = p.Email,
                Surname = p.Surname,
                UserName = p.UserName,
                DepartmentId = p.DepartmentId,
                ImageUrl=p.ImageUrl,
            };
            var result = await _userManager.CreateAsync(appUser, p.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View();
        }


    }
}
