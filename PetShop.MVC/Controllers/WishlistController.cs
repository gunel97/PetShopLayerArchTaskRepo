using Microsoft.AspNetCore.Mvc;
using PetShop.BusinessLogic.Services;

namespace PetShop.MVC.Controllers
{
    public class WishlistController : Controller
    {
        private readonly WishlistManager _wishlistManager;

        public WishlistController(WishlistManager wishlistManager)
        {
            _wishlistManager = wishlistManager;
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            _wishlistManager.AddToWishlist(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _wishlistManager.RemoveFromWishlist(id);
            return NoContent();
        }

        public async Task<IActionResult> Index()
        {
            var wishlist = await _wishlistManager.GetWishlistAsync();

            return View(wishlist);
        }
    }
}
