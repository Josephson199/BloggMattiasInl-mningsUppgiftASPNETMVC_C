using System.Collections.Generic;
using BloggMattiasInlämningsUppgiftASPNETMVC_C.Models;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.ViewModels
{
    public class CreatePostViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
