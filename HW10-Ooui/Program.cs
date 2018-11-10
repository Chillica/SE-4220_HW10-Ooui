using System;
using Ooui;
using System.Diagnostics;
using Xamarin.Forms;
using HW10.Shared.ViewModel;

namespace HW10_Ooui
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            var vm = new MainViewModel(new OouiPlatformServices());
            UI.Publish("/", new MainWindow() { BindingContext = vm }.GetOouiElement());
            //var page = new MainWindow();
            //UI.Publish("/", page.GetOouiElement());
#if DEBUG
            UI.Port = 12345;
            UI.Host = "localhost";
            Process.Start("explorer", $"http://{UI.Host}:{UI.Port}");
            Console.ReadLine();
#endif
        }
    }
}
