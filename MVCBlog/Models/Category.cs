using System;
using System.Collections.Generic;

namespace MVCBlog.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
