using System.Collections.Generic;
using Lecture06.BlogPosts.EntityFramework.Domain;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostsViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}