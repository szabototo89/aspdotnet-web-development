using System;
using System.Windows.Input;

namespace Lecture08.BlogPosts.Admin.ViewModels
{
    public class ActionCommand : ICommand
    {
        private readonly Action action;

        public ActionCommand(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            this.action = action;
        }

        public Boolean CanExecute(Object parameter) => true;

        public void Execute(Object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged;
    }
}