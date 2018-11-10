using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace HW10.Shared.ViewModel
{
    public class LocationTreeViewModel : INotifyPropertyChanged
    {
        public LocationTreeViewModel(ObservableCollection<Location> locations, IPlatformServices platformServices)
        {
            Locations = locations;
            SelectedLocation = locations?.FirstOrDefault();
            this.platformServices = platformServices;
        }

        public ObservableCollection<Location> Locations { get; }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set { SetField(ref selectedLocation, value); }
        }

        int childNumber = 1;
        private ICommand addSingleLocation;
        public ICommand AddSingleLocation => addSingleLocation ?? (addSingleLocation = platformServices.CreateCommand(
            () => SelectedLocation.Children.Add(new Location() { Name = $"Child {childNumber++}" })));

        private readonly IPlatformServices platformServices;

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
