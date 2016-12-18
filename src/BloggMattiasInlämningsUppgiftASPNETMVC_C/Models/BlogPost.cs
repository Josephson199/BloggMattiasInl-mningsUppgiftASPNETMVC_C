using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders;

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Models
{
    public partial class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please add a Headline.")]
        [StringLength(50, ErrorMessage = "To many characters, maximum of 50.")]
        public string HeadLine { get; set; }
        [Required(ErrorMessage = "Please add a text.")]
        [StringLength(2000, ErrorMessage = "To many characters, maximum of 2000.")]
        
        public string TextBody { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
