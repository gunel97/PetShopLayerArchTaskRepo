using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.Services;

public class FooterManager : IFooterService
{
    private readonly ISocialService _socialService;
    private readonly IBioService _bioService;

    public FooterManager(ISocialService socialService, IBioService bioService)
    {
        _socialService = socialService;
        _bioService = bioService;
    }

    public async Task<FooterViewModel> GetFooterViewModel()
    {
        var socials = await _socialService.GetAllAsync(predicate:x=>!x.IsDeleted);
        var bio = await _bioService.GetAllAsync();

        var footerViewModel = new FooterViewModel
        {
            Socials = socials.ToList(),
            Bio=bio.FirstOrDefault()
        };

        return footerViewModel;
    }
}
