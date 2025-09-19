using Microsoft.Extensions.DependencyInjection;
using PetShop.BusinessLogic.Mapping;
using PetShop.BusinessLogic.Services;
using PetShop.BusinessLogic.Services.Contracts;

namespace PetShop.BusinessLogic;

public static class BusinessLogicLayerServiceRegistration
{
    public static IServiceCollection AddBusinessLogicLayerServices(this IServiceCollection services)
    {
        services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
        services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudManager<,,,>));
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IPostService, PostManager>();
        services.AddScoped<IBioService, BioManager>();
        services.AddScoped<ISocialService, SocialManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<IHomeService, HomeManager>();
        services.AddScoped<IHeaderService, HeaderManager>();
        services.AddScoped<IFooterService, FooterManager>();
        services.AddScoped<IReviewService, ReviewManager>();
        services.AddScoped<FileService>();
        services.AddScoped<BasketManager>();
        services.AddScoped<WishlistManager>();

        return services;
    }
}
