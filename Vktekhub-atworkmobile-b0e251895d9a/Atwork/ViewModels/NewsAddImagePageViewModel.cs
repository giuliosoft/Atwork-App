using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    class NewsAddImagePageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _field;
        #endregion

        #region Properties
        public string Field
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
                OnPropertyChanged(nameof(Field));
            }
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Delegates
        public Command xxCommand { get; }
        #endregion

        #region Contructor

        public NewsAddImagePageViewModel()
        {
            xxCommand = new Command(xxAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private async void xxAction()
        {
            await xxMethod();
        }

        #endregion

        #region Private Methods
        private async Task xxMethod()
        {

        }

        #endregion

    }
}
