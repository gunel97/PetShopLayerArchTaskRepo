using Microsoft.AspNetCore.Identity;
namespace PetShop.DA.DataContext.Entities;

public class AppUser:IdentityUser
{
    public string? FullName { get; set; }
    public string? ProfileImageName { get; set; }
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}

