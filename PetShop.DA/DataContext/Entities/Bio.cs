
namespace PetShop.DA.DataContext.Entities;

public class Bio:TimeStample
{
    public string LogoUrl { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
}
