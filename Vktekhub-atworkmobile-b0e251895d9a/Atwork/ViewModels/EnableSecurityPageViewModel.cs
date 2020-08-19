using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System;

namespace Atwork.ViewModels
{
    public class EnableSecurityPageViewModel : INotifyPropertyChanged
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
        public Command EnableCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Contructor

        public EnableSecurityPageViewModel()
        {
            EnableCommand = new Command(EnableAction);
            EnableCommand = new Command(CancelAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private async void EnableAction()
        {
            //present a msg to ask which security feature to enable.
            //face id or touch id
            string action = await DisplayActionSheet("Select a security method:", "Cancel", null, "Touch Id", "Face Id");
            switch(action)
            {
                case "Cancel":
                    CancelAction();
                    break;
                case "Touch Id":
                    EnableTouchId();
                    break;

                case "Face Id":
                    EnableFaceId();
                    break;

                default:
                    break;
            }
        }

        

        private void CancelAction()
        {
            //TODO nav back to login?
        }
        #endregion

        #region Private Methods
        private Task<string> DisplayActionSheet(string v1, string v2, object p, string v3, string v4)
        {
            //TODO what is the config of this task method?
            throw new NotImplementedException();
        }

        private void EnableTouchId()
        {
            //need to get
        }

        private void EnableFaceId()
        {

        }
        #endregion

    }
}


