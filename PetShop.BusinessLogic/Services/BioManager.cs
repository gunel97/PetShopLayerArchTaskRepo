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
    public class BioManager :
        CrudManager<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel>,
        IBioService
    {
        public BioManager(IRepository<Bio> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
