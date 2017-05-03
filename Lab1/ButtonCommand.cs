using System;
using System.Windows.Input;

namespace Lab1
{
    internal class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged; 

 
        public bool CanExecute(object parameter)
        { 
            return true; 
        } 
 
        public void Execute(object parameter)
        { 
        } 

    }
}