using System.Collections.Generic;
using Lecture03.BlogPosts.EntityFramework.Domain;

namespace Lecture03.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}