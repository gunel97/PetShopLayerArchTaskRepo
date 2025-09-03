using PetShop.DA.DataContext;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;

namespace PetShop.DA.Repositories
{
    public class ProductRepository : EfCoreRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {
                
        }
    }
}
