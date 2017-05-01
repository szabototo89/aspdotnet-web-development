using System;
using System.Collections.Generic;
using System.Linq;
using Lecture08.BlogPosts.EntityFramework.Contexts;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.EntityFramework.Repositories
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

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToArray();
        }

        public void AddAuthor(String fullName)
        {
            if (fullName == null) throw new ArgumentNullException(nameof(fullName));

            context.Authors.Add(new Author
            {
                FullName = fullName,
                BlogPosts = Enumerable.Empty<BlogPost>().ToList()
            });

            context.SaveChanges();
        }

        public void AddBlogPost(String title, IEnumerable<String> authors, String content)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (content == null) throw new ArgumentNullException(nameof(content));

            context.BlogPosts.Add(new BlogPost
            {
                Title = title,
                Authors = Enumerable.Empty<Author>().ToList(),
                Content = content,
                CreatedDate = DateTime.Now
            });

            context.SaveChanges();
        }

        public void EditBlogPost(Int32 id, String title, IEnumerable<Author> authors, String content)
        {
            var actualBlogPost = context.BlogPosts.FirstOrDefault(blogPost => blogPost.Id == id);

            if (actualBlogPost == null) return;

            actualBlogPost.Title = title ?? actualBlogPost.Title;
            actualBlogPost.Authors = (authors ?? actualBlogPost.Authors ?? Enumerable.Empty<Author>()).ToList();
            actualBlogPost.Content = content ?? actualBlogPost.Content;

            context.SaveChanges();
        }

        public void DeleteAuthor(Int32 id)
        {
            var actualAuthor = context.Authors.FirstOrDefault(author => author.Id == id);
            if (actualAuthor == null) return;
            context.Authors.Remove(actualAuthor);
            context.SaveChanges();
        }

        public void ChangeAuthor(Int32 id, String fullName)
        {
            if (fullName == null) throw new ArgumentNullException(nameof(fullName));

            var actualAuthor = context.Authors.FirstOrDefault(author => author.Id == id);
            if (actualAuthor == null) return;

            actualAuthor.FullName = fullName;
            context.SaveChanges();
        }
    }
}