using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Location : INotifyPropertyChanged, IDataErrorInfo
    {
        public Location() : this(locName: null, description: null)
        {

        }

        public Location(string locName = null, string description = null)
        {
            _locName = locName;
            _description = description;
            Children.CollectionChanged += (s, e) => OnPropertyChanged(nameof(Children));
        }

        private string _locName;
        public string Name
        {
            get { return _locName; }
            set { SetField(ref _locName, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetField(ref _description, value); }
        }

        private ObservableCollection<Location> children;
        public ObservableCollection<Location> Children => children ?? (children = new ObservableCollection<Location>());


        private Dictionary<string, string> errors = new Dictionary<string, string>();
        public string Error => null;
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;

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
