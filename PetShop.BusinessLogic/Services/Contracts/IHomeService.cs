using PetShop.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services.Contracts
{
    public interface IHomeService
    {
        Task<HomeViewModel> GetHomeViewModel();
    }
}
