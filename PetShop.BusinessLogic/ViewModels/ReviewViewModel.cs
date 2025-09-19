using Microsoft.AspNetCore.Http;
using PetShop.DA.DataContext.Entities;
namespace PetShop.BusinessLogic.ViewModels;

public class ReviewViewModel
{
    public int Id { get; set; }
    public float Rate { get; set; }
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? AppUserId { get; set; }
    public string? AppUserName { get; set; }
    public string? AppUserProfileImageName { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ReviewCreateViewModel
{
    public float Rate { get; set; }
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string Description { get; set; } = null!;
    public int ProductId { get; set; }
    public string? AppUserId { get; set; }

    public IFormFile? ImageFile { get; set; }
    public ReviewStatus ReviewStatus { get; set; }
}

public class ReviewUpdateViewModel
{
    public int Id { get; set; }
    public float Rate { get; set; }
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public int ProductId { get; set; }
    public string? AppUserId { get; set; }
    public IFormFile? ImageFile { get; set; }
    public ReviewStatus ReviewStatus { get; set; }
}


