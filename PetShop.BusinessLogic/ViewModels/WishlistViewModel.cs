using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.ViewModels
{
    public class WishlistItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class WishlistCookieItemViewModel
    {
        public int ProductId { get; set; }
    }
}
