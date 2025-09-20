using Microsoft.AspNetCore.Mvc;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.Repositories.Contracts;
using System.Threading.Tasks;

namespace PetShop.MVC.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (CategoryCreateViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existedCategory  = await _categoryService.GetAsync(predicate: x=>x.Name.ToLower()==createViewModel.Name.ToLower());

            if (existedCategory!=null)
            {
                ModelState.AddModelError("Name", "This category exists");
                
                return View();
            }

            await _categoryService.CreateAsync(createViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var categoryViewModel = await _categoryService.GetByIdAsync(id);

            if (categoryViewModel == null)
                return NotFound();

            var updateViewModel = new CategoryUpdateViewModel
            {
                Name = categoryViewModel.Name!,
                IsDeleted = categoryViewModel.IsDeleted
            };

            return View(updateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update (int id, CategoryUpdateViewModel updateViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateViewModel);

            var existedCategory  = await _categoryService.GetByIdAsync(id);

            if (existedCategory == null)
                return BadRequest();

            var existedName = await _categoryService.GetAsync(predicate: x=>x.Name.ToLower()==updateViewModel.Name.ToLower());
            
            if (existedName != null)
            {
                ModelState.AddModelError("Name", "This category exists");

                return View(updateViewModel);
            }

            existedCategory.Name=updateViewModel.Name;
            existedCategory.IsDeleted=updateViewModel.IsDeleted;

            var updated = await _categoryService.UpdateAsync(id, updateViewModel);

            if (updated)
                return RedirectToAction(nameof(Index));
            else
                return View(updateViewModel);
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return BadRequest();

          var deleted = await _categoryService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            else
                return RedirectToAction(nameof(Index));

        }
    }
}
