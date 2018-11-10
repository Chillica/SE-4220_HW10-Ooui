using System;
using Ooui;
using System.Diagnostics;
using Xamarin.Forms;

namespace HW10_Ooui
{
    class Program
    {
        static void Main(string[] args)
        {
            Forms.Init();
            //var platformServices = new OouiPlatformServices();
            //var vm = new MainViewModel(platformServices);
            //UI.Publish("/", new MainPage() { BindingContext = vm }.GetOouiElement());
            var page = new MainWindow();
            UI.Publish("/", page.GetOouiElement());
#if DEBUG
            UI.Port = 12345;
            UI.Host = "localhost";
            Process.Start("explorer", $"http://{UI.Host}:{UI.Port}");
            Console.ReadLine();
#endif
        }
    }
}
