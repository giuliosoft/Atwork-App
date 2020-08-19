using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Atwork.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SignUpWelcomePageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _username;
        private string _token;
        #endregion

        #region Properties
        public string ResponseMessage { get; set; }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                OnPropertyChanged(nameof(Token));
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
        public Command EmailSignupCommand { get; }
        #endregion

        #region Constructor
        public SignUpWelcomePageViewModel()
        {
            EmailSignupCommand = new Command(EmailSignupAction);
        }
        #endregion

        #region Commands
        public async void EmailSignupAction()
        {
            Login loginModel = new Login();
            loginModel.UserName = UserName;
            string Password = "signup";

            using (var client = new HttpClient())
            {
                
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/login/validate", content);
                if (response.IsSuccessStatusCode)
                {
                    //success stuff
                    string contentString = await response.Content.ReadAsStringAsync();
                    loginModel = JsonConvert.DeserializeObject<Login>(contentString);
                    Storage.SetKeyValue("useremail", loginModel.UserEmail);
                    Storage.SetKeyValue("password", loginModel.Password);


                    SignUpWithEmailClaimPageViewModel claim = new SignUpWithEmailClaimPageViewModel(loginModel);
                    SignUpWithEmailClaimPage claimPage = new SignUpWithEmailClaimPage();
                    //load the view model with profile info
                    claimPage.BindingContext = claim;
                    await Application.Current.MainPage.Navigation.PushAsync(claimPage);
                }
                else
                {
                    //login failed
                    ResponseMessage = "Username validation failed!";
                }

            }

        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion
    }
}
