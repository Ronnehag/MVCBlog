using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models;
using MVCBlog.ViewModels;
using System;
using System.Linq;

namespace MVCBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new PostsCategoriesViewModel(_context)
            {
                Posts = _context.Post.OrderByDescending(p => p.PostDate).Take(10).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var mod = new CreateBlogViewModel();
            mod.Categories = _context.Category;

            return View(mod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PostDate = DateTime.Now;
                _context.Add(post);
                _context.SaveChanges();
                ModelState.Clear();
                return Redirect("Index");
            }
            var model = new CreateBlogViewModel(
                _context.Category.AsEnumerable(), new PostMetaData());

            return View(model);
        }

        public IActionResult ViewPost(int id)
        {
            var model = _context.Post
                .Include("Category")
                .FirstOrDefault(p => p.PostId == id);
            return View(model);
        }
    }
}