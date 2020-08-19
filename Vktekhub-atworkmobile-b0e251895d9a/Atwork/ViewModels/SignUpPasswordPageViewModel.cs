using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SignUpPasswordPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _passwordEntryLabelText;
        private string _newPassword;
        private string _setConfirmButtonText;
        private Login _login;
        #endregion

        #region Properties
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public string PasswordEntryLabel
        {
            get
            {
                return _passwordEntryLabelText;
            }
            set
            {
                _passwordEntryLabelText = value;
                OnPropertyChanged(nameof(PasswordEntryLabel));
            }
        }

        public string SetConfirmButtonText
        {
            get
            {
                return _setConfirmButtonText;
            }
            set
            {
                _setConfirmButtonText = value;
                OnPropertyChanged(nameof(SetConfirmButtonText));
            }
        }


        #endregion

        #region Delegates
        public Command CreatePasswordCommand { get; }
        public Command ConfirmPasswordCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public SignUpPasswordPageViewModel()
        {
            CreatePasswordCommand = new Command(CreatePasswordAction);
            SetConfirmButtonText = "Create Password";
            PasswordEntryLabel = "Create your password";
            
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private async void CreatePasswordAction()
        {
            ProfileRecord profile = new ProfileRecord();
            //TODO get new token with new password

            _login.Password = NewPassword;
            profile.volUserPassword = NewPassword;
            profile.volEmail = _login.UserEmail;
            using (var client = new HttpClient())
            {
                //string token = Storage.GetKeyValue("token");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string UserEmail = Storage.GetKeyValue("useremail");
                string Password = "onboarding"; //onboarding key
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserEmail}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/updatepassword", content);
                if (response.IsSuccessStatusCode)
                {
                    Storage.SetKeyValue("password", NewPassword);
                    LoginEntryPageViewModel vm = new LoginEntryPageViewModel();
                    LoginEntryPage loginPage = new LoginEntryPage();
                    loginPage.BindingContext = vm;
                    await Application.Current.MainPage.Navigation.PushAsync(loginPage);

                }
                else
                {
                    //ResponseMessage 
                }

            }
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
