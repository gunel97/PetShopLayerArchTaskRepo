namespace PetShop.DA.DataContext.Entities;

public class PostImage : TimeStample
{
    public string ImageName { get; set; } = null!;
    public int PostId { get; set; }
    public Post? Post { get; set; }
}



