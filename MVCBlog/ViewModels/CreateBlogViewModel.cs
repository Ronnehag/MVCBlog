using System.Collections.Generic;
using MVCBlog.Models;

namespace MVCBlog.ViewModels
{
    public class CreateBlogViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public PostMetaData Post { get; set; }


        public CreateBlogViewModel() { }

        public CreateBlogViewModel(IEnumerable<Category> categories, PostMetaData post)
        {
            Categories = categories;
            Post = post;
        }
    }
}
