using Atwork.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupAllowNotificationsPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private int _allowNotifications;
        #endregion

        #region Properties
        public int AllowNotifications
        {
            get
            {
                return _allowNotifications;
            }
            set
            {
                _allowNotifications = value;
                OnPropertyChanged(nameof(AllowNotifications));
            }
        }

        #endregion

        #region Delegates
        public Command SavePreferenceCommand;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor
        public SetupAllowNotificationsPageViewModel()
        {
            SavePreferenceCommand = new Command(SavePreferenceAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private void SavePreferenceAction()
        {

        }
        #endregion

        #region Private Methods

        #endregion
    }
}
