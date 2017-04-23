using System;
using System.Collections.Generic;
using Lecture06.BlogPosts.EntityFramework.Domain;

namespace Lecture06.BlogPosts.EntityFramework.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetBlogPosts();
        void AddBlogPost(String title, IEnumerable<String> authors, String content);
        void EditBlogPost(Int32 id, String title, IEnumerable<String> authors, String content);
    }
}
