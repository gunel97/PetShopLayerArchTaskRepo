using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.ViewModels
{
    public class SocialViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }

    public class SocialCreateViewModel
    {
        public string Url { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }

    public class SocialUpdateViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public bool IsDeleted {  get; set; }
    }
}
