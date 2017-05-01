using System;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public class DetailedAuthorContext : ViewModelBase
    {
        private String fullName;

        public String FullName
        {
            get { return fullName; }
            set
            {
                fullName = value; 
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
}