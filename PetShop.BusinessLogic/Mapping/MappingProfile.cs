using AutoMapper;
using PetShop.BusinessLogic.Services;
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

        CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category == null ? "" : src.Category.Name))
            .ForMember(x => x.ImageNames, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageName).ToList()))
            .ForMember(x => x.TagNames, opt => opt.MapFrom(src => src.ProductTags.Select(t => t.Tag != null ? t.Tag.Name : "").ToList()))
            .ReverseMap();
        CreateMap<Product, ProductCreateViewModel>().ReverseMap();
        CreateMap<Product, ProductUpdateViewModel>().ReverseMap();

        CreateMap<Post, PostViewModel>()
            .ForMember(x => x.ImageNames, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageName).ToList()))
            .ForMember(x => x.TagNames, opt => opt.MapFrom(src => src.PostTags.Select(t => t.Tag != null ? t.Tag.Name : "").ToList()))
            .ReverseMap();
        CreateMap<Post, PostCreateViewModel>().ReverseMap();
        CreateMap<Post, PostUpdateViewModel>().ReverseMap();

        CreateMap<Bio, BioViewModel>().ReverseMap();
        CreateMap<Bio, BioCreateViewModel>().ReverseMap();
        CreateMap<Bio, BioUpdateViewModel>().ReverseMap();

        CreateMap<Social, SocialViewModel>().ReverseMap();
        CreateMap<Social, SocialCreateViewModel>().ReverseMap();
        CreateMap<Social, SocialUpdateViewModel>().ReverseMap();

        CreateMap<Review, ReviewUpdateViewModel>().ReverseMap();
        CreateMap<Review, ReviewCreateViewModel>().ReverseMap();
        CreateMap<Review, ReviewViewModel>()
            .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Product == null ? "" : src.Product.Name))
            .ForMember(x => x.AppUserName, opt => opt.MapFrom(src => src.AppUser == null ? "" : src.AppUser.UserName))
            .ForMember(x => x.AppUserProfileImageName, opt => opt.MapFrom(src => src.AppUser==null ? "" : src.AppUser.ProfileImageName))
            .ReverseMap();

    }
}
