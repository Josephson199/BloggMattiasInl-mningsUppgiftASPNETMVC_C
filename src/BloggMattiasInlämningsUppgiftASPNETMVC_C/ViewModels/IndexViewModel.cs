using System.Collections.Generic;
using BloggMattiasInlämningsUppgiftASPNETMVC_C.Models;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<BlogPost> BlogPostList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public string SearchString { get; set; }
        public int CategoryId { get; set; } 
    }
}
