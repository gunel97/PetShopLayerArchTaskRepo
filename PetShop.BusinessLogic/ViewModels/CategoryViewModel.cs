namespace PetShop.BusinessLogic.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name {get; set;}
    public bool IsDeleted { get; set; }
}

public class CategoryCreateViewModel
{
    public string Name { get; set; } = null!;
}
public class CategoryUpdateViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
}

