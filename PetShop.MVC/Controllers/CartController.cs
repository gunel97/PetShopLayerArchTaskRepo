using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PetShop.BusinessLogic.Services;
using System.Threading.Tasks;

namespace PetShop.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly BasketManager _basketManager;

        public CartController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketManager.GetBasketAsync();

            return View(basket);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int productId, int change)
        {
            var basketViewModel  = await _basketManager.ChangeQuantityAsync(productId, change);
            var cartHtml = await RenderPartialViewToString("_CartPartialView", basketViewModel);

            return Json(new
            {
                success = true,
                basketViewModel,
                cartHtml
            });
        }

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using var writer = new StringWriter();

            var viewEngine = HttpContext.RequestServices.GetService<ICompositeViewEngine>();
            var viewResult = viewEngine.FindView(ControllerContext, viewName, false);

            if (!viewResult.Success)
            {
                throw new InvalidOperationException($"Could not find view {viewName}");
            }

            var viewContext = new ViewContext(
                ControllerContext, 
                viewResult.View,
                ViewData,
                TempData,
                writer,
                new HtmlHelperOptions()
                );

            await viewResult.View.RenderAsync(viewContext);
            return writer.ToString();
        }
    }
}
