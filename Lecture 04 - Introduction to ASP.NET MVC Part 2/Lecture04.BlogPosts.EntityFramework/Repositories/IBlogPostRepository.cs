using System.Collections.Generic;
using Lecture04.BlogPosts.EntityFramework.Domain;

namespace Lecture04.BlogPosts.EntityFramework.Repositories
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetBlogPosts();
    }
}
