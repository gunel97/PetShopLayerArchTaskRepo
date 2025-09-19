using AutoMapper;
using PetShop.BusinessLogic.Constants;
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
    public class ReviewManager : CrudManager<Review, ReviewViewModel, ReviewCreateViewModel, ReviewUpdateViewModel>, IReviewService
    {
        private readonly FileService _fileService;
        public ReviewManager(IRepository<Review> repository,
                             IMapper mapper, FileService fileService) : base(repository, mapper)
        {
            _fileService = fileService;
        }

        public override async Task CreateAsync(ReviewCreateViewModel model)
        {
            if (model.ImageFile != null)
                model.ImageName = await _fileService.GenerateFile(model.ImageFile, FilePathConstants.ReviewImagePath);


            await base.CreateAsync(model);
        }
    }
}
