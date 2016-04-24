using System;
using System.Windows.Input;
using SuperheroManager.AdministrationApp.Annotations;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class ActionCommand : ICommand
    {
        private readonly Action execute;
        private readonly Predicate<Object> canExecute;

        public ActionCommand([NotNull] Action execute, Predicate<Object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.canExecute = canExecute ?? (parameter => true);
        }

        public Boolean CanExecute(Object parameter)
        {
            return this.canExecute(parameter);
        }

        public void Execute(Object parameter)
        {
            this.execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}