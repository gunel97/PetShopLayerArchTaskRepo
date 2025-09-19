using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;

namespace PetShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;
        private readonly UserManager<AppUser> _userManager;
        public ProductController(IProductService productService, IReviewService reviewService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _reviewService = reviewService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Details(string id)
        {
            int productId = int.Parse(id.Split('-').Last());
            //int productId = id.Substring(id.LastIndexOf('-')+1);

            var model = await _productService.GetAsync(predicate: x => x.Id == productId && !x.IsDeleted,
                include:x=>x
                .Include(x=>x.Category!)
                .Include(x=>x.Images)
                .Include(x=>x.ProductTags).ThenInclude(x=>x.Tag!)
                .Include(x=>x.Reviews.Where(x=>x.ReviewStatus==ReviewStatus.Approved))
                .ThenInclude(x=>x.AppUser!));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview (int id, ReviewCreateViewModel createViewModel)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Details", new { id = $"{createViewModel.ProductId}" });
            }

            if (id != createViewModel.ProductId)
            {
                return RedirectToAction("Details", new { id = $"{createViewModel.ProductId}" });
            }

            if (User.Identity!.IsAuthenticated)
            {
                // createViewModel.AppUserId = User.Claims.FirstOrDefault(x=>x.Type=="http://schemas.xmlsoap.org/ws/2005/05/identity/claims")?.Value ;
                var user = await _userManager.FindByNameAsync(User.Identity!.Name);
                createViewModel.AppUserId = user!.Id;
            }

            createViewModel.ReviewStatus = ReviewStatus.Pending;

            await _reviewService.CreateAsync(createViewModel);

            return RedirectToAction("Details", new { id = $"{createViewModel.ProductId}" });
        }
    }
}
