using System;
using System.Collections.Generic;
using System.Linq;
using Lecture04.BlogPosts.EntityFramework.Contexts;
using Lecture04.BlogPosts.EntityFramework.Domain;

namespace Lecture04.BlogPosts.EntityFramework.Repositories
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
    }
}