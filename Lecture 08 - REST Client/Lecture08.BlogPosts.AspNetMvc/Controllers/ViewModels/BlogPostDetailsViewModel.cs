using System;
using System.Collections.Generic;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.AspNetMvc.Controllers.ViewModels
{
    public class BlogPostDetailsViewModel
    {
        public BlogPostDetailsViewModel(BlogPost blogPost)
        {
            BlogPost = blogPost;
        }

        public BlogPost BlogPost { get; }

        public Boolean IsEditing => BlogPost != null;

        public Int32? Id => BlogPost?.Id;

        public String Title => BlogPost?.Title;

        public String Content => BlogPost?.Content;

        public IEnumerable<Author> Authors => BlogPost?.Authors;
    }
}