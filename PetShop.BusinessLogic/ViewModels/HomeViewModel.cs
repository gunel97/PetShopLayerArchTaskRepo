using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.ViewModels
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = [];
        public List<ProductViewModel> Products { get; set; } = [];
    }
}
