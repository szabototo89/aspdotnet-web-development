using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lecture03.BlogPosts.EntityFramework.Domain;

namespace Lecture03.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> TopBlogPosts { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}