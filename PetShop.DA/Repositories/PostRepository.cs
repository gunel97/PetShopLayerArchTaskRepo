using PetShop.DA.DataContext;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;

namespace PetShop.DA.Repositories
{
    public class PostRepository : EfCoreRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) :base(context)
        {
                
        }
    }
    
}
