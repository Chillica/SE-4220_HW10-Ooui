using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace HW7.ViewModel
{
    public class CmdViewModel : INotifyPropertyChanged
    {

        private readonly DelegateCommand<string> _clickCharViewListCommand;
        private readonly DelegateCommand<string> _exitCommand;

        public CmdViewModel()
        {

            _clickCharViewListCommand = new DelegateCommand<string>(
                (s) =>
                { /* perform some action */
                    if (IsCharListOpen == false)
                        IsCharListOpen = true;
                    else
                        IsCharListOpen = false;
                }, //Execute
                (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
           );
            _exitCommand = new DelegateCommand<string>(
               (s) =>
               { /* perform some action */
                   System.Windows.Application.Current.Shutdown();
               }, //Execute
               (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
          );
            IsCharListOpen = true;
        }

        private bool isCharListOpen;
        public bool IsCharListOpen
        {
            get { return isCharListOpen; }
            set
            {
                isCharListOpen = value;
                Console.WriteLine("List open: " + isCharListOpen);
                OnPropertyChanged(nameof(IsCharListOpen));
            }
        }

        public DelegateCommand<string> CharViewListCommand
        {
            get { return _clickCharViewListCommand; }
        }

        public DelegateCommand<string> ExitCommand
        {
            get { return _exitCommand; }
        }

        private string _input = "can execute";
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                _clickCharViewListCommand.RaiseCanExecuteChanged();
            }
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
