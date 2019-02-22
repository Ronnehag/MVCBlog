using System;
using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class PostMetaData
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You need to enter a title")]
        [MaxLength(50, ErrorMessage = "Max length for title is 50 characters")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Your post needs content")]
        [MinLength(100, ErrorMessage = "Content needs to be a minimum of 100 characters")]
        [MaxLength(2000, ErrorMessage = "Content can't exceed 2000 characters")]
        public string Text { get; set; }

        public DateTime PostDate { get; set; }

        // Regex matches any starting number 1-9 one or more times.
        // After that any digit zero or more times.
        // value for default <option> tag is 0, "Please select one" and that needs to be flagged for error.
        [RegularExpression(@"^[1-9]+\d*$", ErrorMessage = "You need to select a category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
