using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW7.ViewModel
{
    public class BookDataGridViewModel : INotifyPropertyChanged
    {
        public BindingList<Book> Books { get; set; }

        public BookDataGridViewModel()
        {
            Books = new BindingList<Book>(new[]{
                new Book{Title="Mirror of Revealing", Author="Jacob Ashcraft", Pages=342, Words=67982, Characters=56, Locations=89},
                new Book{Title="Mirror of Silence", Author="Ashcraft", Pages=284, Words=58245, Characters=32, Locations=61},
                new Book{Title="Mirror of Light", Author="Jacob", Pages=311, Words=64197, Characters=46, Locations=80},
                new Book{Title="Mirror of Death", Author="Paul", Pages=300, Words=60000, Characters=60, Locations=120},
            }.ToList());
        }

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
