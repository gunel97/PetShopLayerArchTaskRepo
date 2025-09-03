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

namespace PetShop.BusinessLogic.Services;

public class HeaderManager : IHeaderService
{
    private readonly IBioService _bioService;

    public HeaderManager(IBioService bioService)
    {
        _bioService = bioService;
    }

    public async Task<HeaderViewModel> GetHeaderViewModel()
    {
        var bio = await _bioService.GetAllAsync();

        var headerViewModel = new HeaderViewModel
        {
            Bio = bio.FirstOrDefault()
        };

        return headerViewModel;
    }
}
