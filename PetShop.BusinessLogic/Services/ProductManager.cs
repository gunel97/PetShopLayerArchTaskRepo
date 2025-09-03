using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;
using System.Linq.Expressions;

namespace PetShop.BusinessLogic.Services
{
    public class ProductManager : CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>,
        IProductService
    {
        public ProductManager(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
