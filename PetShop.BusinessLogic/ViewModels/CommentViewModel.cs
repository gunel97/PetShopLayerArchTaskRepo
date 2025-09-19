using Microsoft.AspNetCore.Http;
using PetShop.DA.DataContext.Entities;

namespace PetShop.BusinessLogic.ViewModels;

public class CommentViewModel
{
    public int Id { get; set; }
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Content { get; set; }
    public int PostId { get; set; }
    public string? PostName { get; set; }
    public string? AppUserId { get; set; }
    public string? AppUserName { get; set; }
    public string? AppUserProfileImageName { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ParentCommentId { get; set; }
}

public class CommentCreateViewModel
{
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
    public string? AppUserId { get; set; }

    public IFormFile? ImageFile { get; set; }
    public Status Status { get; set; }
}

public class CommentUpdateViewModel
{
    public int Id { get; set; }
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int PostId { get; set; }
    public string? AppUserId { get; set; }
    public IFormFile? ImageFile { get; set; }
    public Status Status { get; set; }
}


