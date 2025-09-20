using Microsoft.AspNetCore.Mvc;

namespace PetShop.MVC.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
