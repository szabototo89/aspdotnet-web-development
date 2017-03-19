using System;
using System.Collections.Generic;
using System.Linq;
using Lecture04.BlogPosts.EntityFramework.Domain;
using Lecture04.BlogPosts.EntityFramework.Repositories;

namespace Lecture04.BlogPosts.AspNetMvc.Repositories
{
    public class TestBlogPostRepository : IBlogPostRepository
    {
        public IEnumerable<BlogPost> GetBlogPosts() =>
            Enumerable.Repeat(0, 100)
                      .Select(element => new BlogPost
                      {
                          Title = "Test Title",
                          CreatedDate = DateTime.Now,
                          Content = "Test Content"
                      });
    }
}