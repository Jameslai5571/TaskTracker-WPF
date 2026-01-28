using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskTracker_WPF.Command
{
    internal abstract class CommandBase : ICommand
    {
        //create base for other command class to implement
        //so they can just inherit this class and not manually implement other interface methods

        public event EventHandler? CanExecuteChanged;

        //optional implementation for inheriting class, has a default function that can be overriden
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        //mandatory implementation for inheriting class
        public abstract void Execute(object? parameter);


        protected void OnCanExecutedChanged()
        {
            //publish out event
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
