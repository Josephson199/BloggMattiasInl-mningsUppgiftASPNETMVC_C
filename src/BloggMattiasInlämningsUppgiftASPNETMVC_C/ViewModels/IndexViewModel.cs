using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Models
{
    public class IndexViewModel
    {
        public IEnumerable<BlogPost> BlogPostList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public string SearchString { get; set; }
        public int CategoryId { get; set; } 
    }
}
