using Microsoft.AspNetCore.Mvc;
using PetShop.BusinessLogic.Services.Contracts;

namespace PetShop.MVC.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly IFooterService _footerService;

        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _footerService.GetFooterViewModel();

            return View(model);
        }
    }
}
