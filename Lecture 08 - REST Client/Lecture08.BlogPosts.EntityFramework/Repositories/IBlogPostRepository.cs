using System;
using System.Collections.Generic;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.EntityFramework.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetBlogPosts();
        void AddBlogPost(String title, IEnumerable<String> authors, String content);
        void EditBlogPost(Int32 id, String title, IEnumerable<Author> authors, String content);
        void AddAuthor(String fullName);
        void DeleteAuthor(Int32 id);
        void ChangeAuthor(Int32 id, String fullName);
    }
}
