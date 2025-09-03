using AutoMapper;
using PetShop.BusinessLogic.ViewModels;
using PetShop.DA.DataContext.Entities;

namespace PetShop.BusinessLogic.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Category, CategoryCreateViewModel>().ReverseMap();
        CreateMap<Category, CategoryUpdateViewModel>().ReverseMap();

        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<Product, ProductCreateViewModel>().ReverseMap();
        CreateMap<Product, ProductUpdateViewModel>().ReverseMap();

        CreateMap<Bio, BioViewModel>().ReverseMap();
        CreateMap<Bio, BioCreateViewModel>().ReverseMap();
        CreateMap<Bio, BioUpdateViewModel>().ReverseMap();

        CreateMap<Social, SocialViewModel>().ReverseMap();
        CreateMap<Social, SocialCreateViewModel>().ReverseMap();
        CreateMap<Social, SocialUpdateViewModel>().ReverseMap();

    }
}
