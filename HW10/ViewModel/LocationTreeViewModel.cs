using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW7.ViewModel
{
    public class LocationTreeViewModel : INotifyPropertyChanged
    {
        public LocationTreeViewModel(ObservableCollection<Location> locations)
        {
            Locations = locations;
            SelectedLocation = locations?.FirstOrDefault();
        }

        public ObservableCollection<Location> Locations { get; }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set { SetField(ref selectedLocation, value); }
        }

        int childNumber = 1;
        private RelayCommand addSingleLocation;
        public RelayCommand AddSingleLocation => addSingleLocation ?? (addSingleLocation = new RelayCommand(
            () => SelectedLocation.Children.Add(new Location() { Name = $"Child {childNumber++}" })));

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
