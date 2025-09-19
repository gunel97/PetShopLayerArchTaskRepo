using PetShop.BusinessLogic.Services.Contracts;
using PetShop.BusinessLogic.ViewModels;

namespace PetShop.BusinessLogic.Services;

public class BlogManager:IBlogService
{
    private readonly IPostService _postService;

    public BlogManager(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<BlogViewModel> GetBlogViewModel()
    {
        var posts = await _postService.GetAllAsync(predicate: x => !x.IsDeleted);

        var blogViewModel = new BlogViewModel
        {
            Posts = posts.ToList(),
        };

        return blogViewModel;
    }
}
