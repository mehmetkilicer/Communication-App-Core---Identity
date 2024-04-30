using Microsoft.AspNetCore.Mvc;

namespace Communication_App_Core.Controllers
{
    public class MainLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
