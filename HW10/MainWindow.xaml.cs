using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HW10;
using HW10.Shared;
using HW10.Shared.ViewModel;

namespace HW10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            var wpfPlatformServices = new WpfPlatformServices();
            vm = new MainViewModel(wpfPlatformServices);
            DataContext = vm;
        }

        public void SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //var vm = DataContext as MainViewModel;
            if (vm != null)
                vm.LocVm.SelectedLocation = e.NewValue as Location;
        }
    }
}
