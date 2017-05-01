using System.Collections.Generic;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostsViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}