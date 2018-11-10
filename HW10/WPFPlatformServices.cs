using System;
using HW10.Shared;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace HW10
{
    public class WpfPlatformServices : IPlatformServices
    {
        public ICommand CreateCommand(Action execute)
        {
            return new RelayCommand(execute);
        }

        public ICommand CreateCommand(Action execute, Func<bool> canExecute)
        {
            return new RelayCommand(execute, canExecute);
        }

        //public void SendMessage(object message)
        //{
        //    var origOptions = message as TaskDialogOptions;
        //    if (origOptions == null)
        //        return;

        //    var options = new TaskDialogInterop.TaskDialogOptions();
        //    options.Title = origOptions.Title;
        //    options.MainInstruction = origOptions.MainInstruction;
        //    Messenger.Default.Send(options);
        //}
    }
}
