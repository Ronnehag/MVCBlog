using MVCBlog.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVCBlog.ViewModels
{
    public class PostsCategoriesViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Post> RecentPosts { get; set; }
        public List<Category> Categories { get; set; }
        public List<PostsPerMonthAndYear> PostsPerMonth { get; set; }
        public List<PostsPerCategory> PostsPerCategory { get; set; }


        private List<PostsPerCategory> GroupByCategory(IEnumerable<Post> posts)
        {
            return posts.GroupBy(p => p.Category.Name)
                .Select(c => new PostsPerCategory
                {
                    CategoryName = c.Key,
                    Count = c.Count()
                }).ToList();
        }

        private List<PostsPerMonthAndYear> GroupByYearAndMonth(IEnumerable<Post> posts)
        {
            return posts
                .GroupBy(p => p.PostDate.ToString("MMMM yyyy"))
                .Select(c => new PostsPerMonthAndYear
                {
                    Date = c.Key,
                    Count = c.Count()
                }).ToList();
        }

        public PostsCategoriesViewModel(BlogContext context)
        {
            var posts = context.Post.Include("Category");
            Categories = context.Category.ToList();
            RecentPosts = context.Post.OrderByDescending(p => p.PostDate).Take(5).ToList();
            PostsPerMonth = GroupByYearAndMonth(posts);
            PostsPerCategory = GroupByCategory(posts);
        }

    }



}
