
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;

namespace PetShop.BusinessLogic.Services.Contracts;

public interface IHeaderService 
{
    Task<HeaderViewModel> GetHeaderViewModel();
}
