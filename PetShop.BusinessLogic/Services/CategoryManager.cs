using AutoMapper;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;

namespace PetShop.BusinessLogic.Services;

public class CategoryManager : CrudManager<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>,
    ICategoryService
{
    public CategoryManager(IRepository<Category> repository, IMapper mapper) 
        : base(repository, mapper)
    {
    }
}
