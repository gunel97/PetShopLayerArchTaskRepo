using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services.Contracts
{
    public interface IBioService :ICrudService<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel>
    {
    }
}
