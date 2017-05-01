using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lecture08.BlogPosts.Admin.Properties;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}