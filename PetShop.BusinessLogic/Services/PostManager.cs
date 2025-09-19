using AutoMapper;
using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using PetShop.DA.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services
{
    public class PostManager:CrudManager<Post, PostViewModel, PostCreateViewModel, PostUpdateViewModel>, IPostService
    {
        public PostManager(IRepository<Post> repository, IMapper mapper):base(repository, mapper) { }
    }
}
