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
    public class SocialManager :
        CrudManager<Social, SocialViewModel, SocialCreateViewModel, SocialUpdateViewModel>,
        ISocialService
    {
        public SocialManager(IRepository<Social> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
