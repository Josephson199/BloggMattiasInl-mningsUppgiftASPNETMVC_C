using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Models
{
    public class CreatePostViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
