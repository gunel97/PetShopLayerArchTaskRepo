using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.BusinessLogic.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string DetailsUrl => $"{Name?.Replace(" ", "-").Replace("/", "-")}-{Id}";
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ShortDescription { get; set; }
        public string? CoverImageName { get; set; }
        public IList<string> ImageNames { get; set; } = [];
        public IList<string> TagNames { get; set; } = [];
        public List<CommentViewModel> Comments { get; set; } = [];
    }

    public class PostCreateViewModel
    {
        public string Name { get; set; } = null!;
    }

    public class PostUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }

}
