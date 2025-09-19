namespace PetShop.DA.DataContext.Entities;

public class Comment : TimeStample
{
    public string? ImageName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string Content { get; set; } = null!;
    public int ParentCommentId { get; set; }
    public Status Status { get; set; }
    public int PostId { get; set; }
    public Post? Post { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

}



