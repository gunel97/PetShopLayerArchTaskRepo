
using Microsoft.EntityFrameworkCore.Query;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using System.Linq.Expressions;

namespace PetShop.BusinessLogic.Services.Contracts;

public interface ICategoryService:ICrudService<Category, CategoryViewModel, CategoryCreateViewModel, CategoryUpdateViewModel>
{
 
}
