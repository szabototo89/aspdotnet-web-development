using System.Collections.Generic;
using Lecture05.BlogPosts.EntityFramework.Domain;

namespace Lecture05.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostsViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}