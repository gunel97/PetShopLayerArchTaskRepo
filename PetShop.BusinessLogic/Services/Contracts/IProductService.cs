using Microsoft.EntityFrameworkCore.Query;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using System.Linq.Expressions;

namespace PetShop.BusinessLogic.Services.Contracts;

public interface IProductService:ICrudService<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>
{
 
}
