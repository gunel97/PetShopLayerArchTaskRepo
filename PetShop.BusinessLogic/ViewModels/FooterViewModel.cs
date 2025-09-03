using PetShop.DA.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.ViewModels
{
    public class FooterViewModel
    {
        public List<SocialViewModel> Socials { get; set; } = [];
        public BioViewModel? Bio { get; set; }
    }
}
