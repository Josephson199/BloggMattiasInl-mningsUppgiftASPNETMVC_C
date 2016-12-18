using System;
using System.Collections.Generic;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Models
{
    public partial class Category
    {
        public Category()
        {
            BlogPost = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<BlogPost> BlogPost { get; set; }
    }
}
