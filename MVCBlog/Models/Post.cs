using System;
using System.Collections.Generic;

namespace MVCBlog.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
