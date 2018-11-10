using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW10.Shared.ViewModel
{
    public class CmdViewModel : INotifyPropertyChanged
    {
        public CmdViewModel()
        {

            CharViewListCommand = new DelegateCommand<string>(
                (s) =>
                { /* perform some action */
                    if (IsCharListOpen == false)
                        IsCharListOpen = true;
                    else
                        IsCharListOpen = false;
                }, //Execute
                (s) => { return !string.IsNullOrEmpty(_input); } //CanExecute
           );
            ExitCommand = new DelegateCommand<string>(
               (s) =>
               { /* perform some action */
                   Environment.Exit(0);
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

        public DelegateCommand<string> CharViewListCommand { get; }

        public DelegateCommand<string> ExitCommand { get; }

        private string _input = "can execute";
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                CharViewListCommand.RaiseCanExecuteChanged();
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
