using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeViewers.Wpf.Commands
{
    internal class CommandsBase : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _action;

        public CommandsBase(Action<object> action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter); 
        }
    }
}
