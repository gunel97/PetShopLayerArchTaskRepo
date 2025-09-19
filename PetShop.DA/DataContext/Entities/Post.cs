namespace PetShop.DA.DataContext.Entities;

public class Post:TimeStample 
{
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string CoverImageName { get; set; } = null!;
    public ICollection<PostImage> Images { get; set; } = [];
    public ICollection<PostTag> PostTags { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}



