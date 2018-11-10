using System;
using System.Windows.Input;

namespace HW10.Shared
{
    public interface IPlatformServices
    {
        ICommand CreateCommand(Action execute);
        ICommand CreateCommand(Action execute, Func<bool> canExecute);
        //void SendMessage(object message);
    }

    //public class TaskDialogOptions
    //{
    //    public string Title { get; set; }
    //    public string MainInstruction { get; set; }
    //}
}
