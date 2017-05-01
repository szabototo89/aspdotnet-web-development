using System;
using System.Windows.Input;
using Lecture08.BlogPosts.Admin.Models;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public class ApplicationContext : ViewModelBase
    {
        private readonly DefaultBlogPostRepository repository;

        public ApplicationContext(DefaultBlogPostRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            BlogPostEditorContext = new BlogPostEditorContext(repository);
            AuthorEditorContext = new AuthorEditorContext(repository);

            BlogPostEditorContext.RefreshContext += (sender, args) => OnRefreshContext();
            AuthorEditorContext.RefreshContext += (sender, args) => OnRefreshContext();

            RefreshCommand = new ActionCommand(OnRefreshContext);

            OnRefreshContext();
        }

        private void OnRefreshContext()
        {
            BlogPostEditorContext.RefreshContextAsync();
            AuthorEditorContext.RefreshContextAsync();
        }

        public BlogPostEditorContext BlogPostEditorContext { get; }

        public AuthorEditorContext AuthorEditorContext { get; }

        public ICommand RefreshCommand { get; }
    }
}