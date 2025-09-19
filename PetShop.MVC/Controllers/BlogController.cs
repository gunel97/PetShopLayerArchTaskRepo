using Microsoft.AspNetCore.Mvc;
using PetShop.BusinessLogic.Services.Contracts;

namespace PetShop.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _blogService.GetBlogViewModel();

            return View(model);
        }
    }
}
