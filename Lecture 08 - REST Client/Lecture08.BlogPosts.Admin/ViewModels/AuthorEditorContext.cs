using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using Lecture08.BlogPosts.Admin.Models;
using Lecture08.BlogPosts.Admin.Properties;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public class AuthorEditorContext : ViewModelBase
    {
        private readonly DefaultBlogPostRepository repository;
        private Author selectedAuthor;
        private IEnumerable<Author> authors;

        public event EventHandler RefreshContext;

        public AuthorEditorContext(DefaultBlogPostRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.repository = repository;

            AddAuthor = new ActionCommand(async () => await AddAuthorAsync(DetailedAuthor, repository));
            RemoveAuthor = new ActionCommand(async () => await RemoveAuthorAsync(SelectedAuthor, repository));
            DetailedAuthor = new DetailedAuthorContext();
        }

        private async Task AddAuthorAsync(DetailedAuthorContext author, DefaultBlogPostRepository repository)
        {
            await repository.AddAuthorAsync(author.FullName);
            OnRefreshContext();
        }

        private async Task RemoveAuthorAsync(Author author, DefaultBlogPostRepository repository)
        {
            if (author == null) return;

            Int32 authorId = author.Id;
            await repository.DeleteAuthorAsync(authorId);
            OnRefreshContext();
        }

        public async void RefreshContextAsync()
        {
            Authors = await repository.GetAuthorsAsync();
        }

        public IEnumerable<Author> Authors
        {
            get { return authors; }
            private set
            {
                authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        public DetailedAuthorContext DetailedAuthor { get; }

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }

        public ICommand AddAuthor { get; }

        public ICommand RemoveAuthor { get; }

        protected void OnRefreshContext()
        {
            RefreshContext?.Invoke(this, EventArgs.Empty);
        }
    }
}