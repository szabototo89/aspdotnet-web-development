using System;
using System.Collections.Generic;
using System.Linq;
using Lecture06.BlogPosts.EntityFramework.Contexts;
using Lecture06.BlogPosts.EntityFramework.Domain;

namespace Lecture06.BlogPosts.EntityFramework.Repositories
{
    public class DatabaseBlogPostRepository : IBlogPostRepository
    {
        private readonly LocalDatabaseContext context;

        public DatabaseBlogPostRepository(LocalDatabaseContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            this.context = context;
        }

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return context.BlogPosts.ToArray();
        }

        public void AddBlogPost(String title, IEnumerable<String> authors, String content)
        {
            throw new NotImplementedException();
        }

        public void EditBlogPost(Int32 id, String title, IEnumerable<String> authors, String content)
        {
            throw new NotImplementedException();
        }
    }
}