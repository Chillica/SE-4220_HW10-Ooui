using System;
using System.Text;
using System.Collections.Generic;
using HW10.Shared;
using System.Windows.Input;
using Xamarin.Forms;

namespace HW10_Ooui
{
    public class OouiPlatformServices : IPlatformServices
    {
        public ICommand CreateCommand(Action execute)
        {
            return new Command(execute);
        }

        public ICommand CreateCommand(Action execute, Func<bool> canExecute)
        {
            return new Command(execute, canExecute);
        }

        //public void SendMessage(object message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
