using System.Collections.Generic;
using Lecture04.BlogPosts.EntityFramework.Domain;

namespace Lecture04.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}