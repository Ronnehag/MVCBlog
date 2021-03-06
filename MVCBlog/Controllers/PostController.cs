﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Models;
using MVCBlog.ViewModels;
using System.Linq;

namespace MVCBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogContext _context;

        public PostController(BlogContext context)
        {
            _context = context;
        }

        [Route("Post/Archive/{date}")]
        public IActionResult Archive(string date)
        {
            var model = new PostsCategoriesViewModel(_context)
            {
                Posts = _context.Post
                    .Where(p => p.PostDate.ToString("MMMM yyyy") == date)
                    .OrderByDescending(p => p.PostDate)
                    .ToList()
            };

            return View("../Blog/Index", model);
        }

        [Route("Post/Category/{category}")]
        public IActionResult ByCategoryName(string category)
        {
            var model = new PostsCategoriesViewModel(_context)
            {
                Posts = _context.Post
                    .Include("Category")
                    .Where(p => string.Equals(p.Category.Name, category, StringComparison.CurrentCultureIgnoreCase))
                    .OrderByDescending(p => p.PostDate)
                    .ToList()
            };
            return View("../Blog/Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category(int id)
        {
            var model = new PostsCategoriesViewModel(_context)
            {
                Posts = _context.Post.Where(p => p.CategoryId == id).ToList()
            };
            return View("../Blog/Index", model);
        }

        public IActionResult SearchPost(string search)
        {
            var model = new PostsCategoriesViewModel(_context)
            {
                Posts = _context.Post
                    .Include("Category")
                    .Where(p => p.Title.Contains(search) || p.Category.Name.Contains(search))
                    .ToList()
            };
            return View("../Blog/Index", model);
        }

        [Route("Post/ViewPost/{id}")]
        public IActionResult ViewPost(int id)
        {
            var model = _context.Post
                .Include("Category")
                .FirstOrDefault(p => p.PostId == id);
            return View(model);
        }


    }
}