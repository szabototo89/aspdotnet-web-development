using System;
using System.Collections.Generic;
using System.Linq;
using Lecture06.BlogPosts.EntityFramework.Domain;
using Lecture06.BlogPosts.EntityFramework.Repositories;

namespace Lecture06.BlogPosts.AspNetMvc.Repository
{
    public class MemoryBlogPostRepository : IBlogPostRepository
    {
        private readonly List<BlogPost> blogPosts;

        public MemoryBlogPostRepository()
        {
            blogPosts = Enumerable.Repeat(0, 1)
                                  .Select(element => new BlogPost
                                  {
                                      Title = "Test Title",
                                      CreatedDate = DateTime.Now,
                                      Content = "Test Content"
                                  }).ToList();
        }

        public IEnumerable<BlogPost> GetBlogPosts() => blogPosts;

        private static List<Author> CreateAuthors(IEnumerable<String> authors)
        {
            return authors.Select(name => new Author { FullName = name }).ToList();
        }

        public void AddBlogPost(String title, IEnumerable<String> authors, String content)
        {
            blogPosts.Add(new BlogPost
            {
                Id = blogPosts.Count + 1000,
                Content = content,
                Title = title,
                CreatedDate = DateTime.Now,
                Authors = CreateAuthors(authors)
            });
        }

        public void EditBlogPost(Int32 id, String title, IEnumerable<String> authors, String content)
        {
            var editedBlogPost = blogPosts.FirstOrDefault(blogPost => blogPost.Id == id);

            if (editedBlogPost == null)
                throw new Exception($"Invalid blog post id: {id}.");

            editedBlogPost.Title = title;
            editedBlogPost.Content = content;
            editedBlogPost.Authors = CreateAuthors(authors);
        }
    }
}