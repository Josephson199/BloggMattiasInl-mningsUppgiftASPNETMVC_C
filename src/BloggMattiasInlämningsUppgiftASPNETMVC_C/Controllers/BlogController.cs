using System;
using System.Linq;
using BloggMattiasInlämningsUppgiftASPNETMVC_C.Models;
using BloggMattiasInlämningsUppgiftASPNETMVC_C.ViewModels;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloggMattiasInlämningsUppgiftASPNETMVC_C.Controllers
{
    public class BlogController : Controller
    {

        private readonly MattiasBlogContext _context;

        public BlogController(MattiasBlogContext context)
        {
            _context = context;
        }

        // GET: /<controller>/

        [HttpGet]
        public IActionResult Index()
        {
           
            var blogPostList = _context.BlogPost.ToList();
            var categoryList = _context.Category.ToList();

           var sortedBlogPostList = blogPostList.OrderByDescending(x => x.CreationDate);

            var model = new IndexViewModel
            {
                BlogPostList = sortedBlogPostList,
                CategoryList = categoryList
            };

            return View(model);
        }
        
       
        [HttpPost]
        public IActionResult IndexSearch(IndexViewModel model)
        {
            if (model.SearchString != null)
            {
                var blogPostList =
                    _context.BlogPost.Where(x => x.HeadLine.Contains(model.SearchString))
                        .ToList()
                        .OrderByDescending(x => x.CreationDate);

                model.BlogPostList = blogPostList;
            }
            else
            {
                var blogPostList = _context.BlogPost.OrderByDescending(x => x.CreationDate).ToList();
                model.BlogPostList = blogPostList;
            }


            model.CategoryList = _context.Category.ToList();

            return View("Index", model);
        }




        [HttpGet]
        public IActionResult IndexCategoryResult(int categoryId)
        {

            var blogPostList = _context.BlogPost.Where(x => x.CategoryId == categoryId).ToList();
            var categoryList = _context.Category.ToList();

            var sortedBlogPostList = blogPostList.OrderByDescending(x => x.CreationDate);

            var model = new IndexViewModel
            {
                BlogPostList = sortedBlogPostList,
                CategoryList = categoryList
            };

            return View("Index", model);
        }
       
      




        [HttpGet]
        public IActionResult CreatePost()
        {
            var model = new CreatePostViewModel{CategoryList = _context.Category.ToList()};
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    model.BlogPost.CreationDate = DateTime.Now;

                    _context.BlogPost.Add(model.BlogPost);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception )//TODO Log exceptions
                {
                    
                    model.CategoryList = _context.Category.ToList();
                    return View(model);
                    
                }
               
            }
            else
            {
                 
                model.CategoryList = _context.Category.ToList();
                return View(model);
            }
        }
    }
}
