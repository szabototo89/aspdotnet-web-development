using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lecture08.BlogPosts.EntityFramework.Domain;
using Lecture08.BlogPosts.EntityFramework.Repositories;

namespace Lecture08.BlogPosts.Admin.Models
{
    public class DefaultBlogPostRepository
    {
        private readonly String serverAddress;
        private readonly HttpClient httpClient;
        private readonly String authorServerEndpoint;
        private readonly String blogPostServerEndpoint;

        public DefaultBlogPostRepository(String serverAddress)
        {
            if (serverAddress == null) throw new ArgumentNullException(nameof(serverAddress));

            httpClient = new HttpClient();
            this.serverAddress = serverAddress;
            authorServerEndpoint = $"{serverAddress}/api/author";
            blogPostServerEndpoint = $"{serverAddress}/api/blog-post";
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            try
            {
                var responseMessage = await httpClient.GetAsync(blogPostServerEndpoint);
                var authors = await GetAuthorsAsync();
                var blogPosts = await responseMessage.Content.ReadAsAsync<IEnumerable<BlogPostDataTransfer>>();
                return blogPosts.Select(blogPost => new BlogPost
                {
                    Id = blogPost.Id,
                    Content = blogPost.Content,
                    Title = blogPost.Title,
                    Authors = blogPost.Authors
                                      .Select(authorId =>
                                          authors.FirstOrDefault(author => author.Id == authorId))
                                      .ToList()
                });
            }
            catch (Exception)
            {
                return Enumerable.Empty<BlogPost>();
            }
        }

        public void AddBlogPost(String title, IEnumerable<String> authors, String content)
        {
            throw new NotImplementedException();
        }

        public void EditBlogPost(Int32 id, String title, IEnumerable<String> authors, String content)
        {
            throw new NotImplementedException();
        }

        public async Task AddAuthorAsync(String fullName)
        {
            await httpClient.PostAsJsonAsync(authorServerEndpoint, fullName);
        }

        public async Task DeleteAuthorAsync(Int32 id)
        {
            await httpClient.DeleteAsync($"{authorServerEndpoint}/{id}");
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            try
            {
                var responseMessage = await httpClient.GetAsync(authorServerEndpoint);
                var authors = await responseMessage.Content.ReadAsAsync<IEnumerable<Author>>();
                return authors;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Author>();
            }
        }

        public async Task AssignAuthorToBlogPostAsync(Int32 blogPostId, Int32 authorId)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<Object>($"{blogPostServerEndpoint}/{blogPostId}?authorId={authorId}", null);
            Console.WriteLine(responseMessage);
        }
    }
}