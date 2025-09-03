namespace PetShop.BusinessLogic.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
}

public class ProductCreateViewModel
{
    public string Name { get; set; } = null!;
}

public class ProductUpdateViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; }
}