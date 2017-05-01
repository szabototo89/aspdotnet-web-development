using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lecture08.BlogPosts.Admin.Models;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public class BlogPostEditorContext : ViewModelBase
    {
        private readonly DefaultBlogPostRepository repository;
        private IEnumerable<BlogPost> blogPosts;
        private BlogPost selectedBlogPost;
        private IEnumerable<Author> authors;
        private Author selectedAuthor;

        public event EventHandler RefreshContext;

        public BlogPostEditorContext(DefaultBlogPostRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;

            AssignCommand = new ActionCommand(async () =>
            {
                if (SelectedAuthor == null || SelectedBlogPost == null) return;
                await repository.AssignAuthorToBlogPostAsync(SelectedBlogPost.Id, SelectedAuthor.Id);
                OnRefreshContext();
            });
        }

        public ICommand AssignCommand { get; }

        public async void RefreshContextAsync()
        {
            var previousSelectedBlogPostId = SelectedBlogPost?.Id;

            BlogPosts = await repository.GetBlogPostsAsync();
            Authors = await repository.GetAuthorsAsync();

            SelectedBlogPost = BlogPosts.FirstOrDefault(blogPost =>
                previousSelectedBlogPostId.HasValue && blogPost.Id == previousSelectedBlogPostId.Value);
        }

        public IEnumerable<Author> Authors
        {
            get { return authors; }
            set
            {
                authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public IEnumerable<BlogPost> BlogPosts
        {
            get { return blogPosts; }
            set
            {
                blogPosts = value;
                OnPropertyChanged(nameof(BlogPosts));
            }
        }

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }

        public BlogPost SelectedBlogPost
        {
            get { return selectedBlogPost; }
            set
            {
                selectedBlogPost = value;
                OnPropertyChanged(nameof(SelectedBlogPost));
            }
        }

        protected void OnRefreshContext()
        {
            RefreshContext?.Invoke(this, EventArgs.Empty);
        }
    }
}