using PetShop.DA.DataContext;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;

namespace PetShop.DA.Repositories
{
    public class CategoryRepository : EfCoreRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        //public override Task CreateAsync(Category entity)
        //{
        //    entity.CreatedAt = DateTime.UtcNow.Date.AddHours(4);
        //    return base.CreateAsync(entity);
        //}

        //public override Task UpdateAsync(Category entity)
        //{
        //    entity.UpdateAt=DateTime.UtcNow.AddHours(4);
        //    return base.UpdateAsync(entity);
        //}
    }
    
}
