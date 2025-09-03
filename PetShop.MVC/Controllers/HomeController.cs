using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.MVC.Models;

namespace PetShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var model  = await _homeService.GetHomeViewModel();

            return View(model);
        }

    }
}
