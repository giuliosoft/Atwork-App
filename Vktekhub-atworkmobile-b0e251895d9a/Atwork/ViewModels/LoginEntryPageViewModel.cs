using System;
using System.Collections.Generic;
using System.Text;
using Atwork.Commands;
using Atwork.Models;
using System.Net;
using Xamarin.Forms;
using Atwork.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace Atwork.ViewModels
{
    public class LoginEntryPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _userEmail;
        private string _userName;
        private string _password;
        private string _responseMessage;
        private bool _isBusy;
        #endregion

        #region Properties
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public string UserEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ResponseMessage
        {
            get
            {
                return _responseMessage;
            }
            set
            {
                _responseMessage = value;
                OnPropertyChanged(nameof(ResponseMessage));
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
        public Command LoginCommand { get; }
        public Command ResetPasswordCommand { get; }
        public Command EnableSecurityCommand { get; }
        #endregion

        #region Contructor

        public LoginEntryPageViewModel()
        {
            ResetPasswordCommand = new Command(ResetPasswordAction);
            LoginCommand = new Command(LoginAction);
            EnableSecurityCommand = new Command(EnableSecurityAction);
            ResponseMessage = String.Empty;
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Private Methods
        private async Task ValidateLogin()
        {

            Login loginModel = new Login();
            loginModel.UserEmail = UserEmail; // User
            loginModel.UserName = UserName;
            loginModel.Password = String.Empty; // Password;
            loginModel.Token = String.Empty;
            loginModel.SetupComplete = Storage.GetKeyValue("setupcomplete");

            //send ajax post to API LoginController

            var b = await LoginPost(loginModel);


            UserEmail = String.Empty;
            UserName = String.Empty;
            Password = String.Empty;

            if (b == true)
            {
                //move into setup sequence if not done before
                if (loginModel.SetupComplete != "Complete")
                {
                    SetupWelcomePage welcomePage = new SetupWelcomePage();
                    SetupWelcomePageViewModel welcomeViewModel = new SetupWelcomePageViewModel();
                    welcomePage.BindingContext = welcomeViewModel;
                    await Application.Current.MainPage.Navigation.PushAsync(welcomePage);
                }
                else
                {
                    FeedTabbedPageViewModel vm = new FeedTabbedPageViewModel("news");
                    FeedTabbedPage feed = new FeedTabbedPage();
                    feed.BindingContext = vm;
                    await Application.Current.MainPage.Navigation.PushAsync(feed);
                }
            }

        }

        private async Task<bool> LoginPost(Login loginModel)
        {
            using (var client = new HttpClient())
            {
                string contentString = string.Empty;
                IsBusy = true;
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                //serialize the model
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/login", content);
                if (response.IsSuccessStatusCode)
                {
                    contentString = await response.Content.ReadAsStringAsync();
                    loginModel = JsonConvert.DeserializeObject<Login>(contentString);
                    //Storage.SetKeyValue("token", loginModel.Token);
                    Storage.SetKeyValue("useremail", UserEmail);
                    Storage.SetKeyValue("username", UserName);
                    Storage.SetKeyValue("password", Password);
                    Storage.SetKeyValue("setupcomplete", loginModel.SetupComplete);
                    Storage.SetKeyValue("companyid", loginModel.CompanyId);

                    UserName = String.Empty;
                    Password = String.Empty;
                    IsBusy = false;
                    return true;
                }
                else
                {
                    //login failed
                    ResponseMessage = $"{response.ReasonPhrase} with Code: {response.StatusCode}";
                    IsBusy = false;
                    return false;
                }

            }
        }

        private void ResetPassword()
        {
            UserName = String.Empty;
            Password = String.Empty;

            var reset = new ResetPasswordPageViewModel();
            ResetPasswordPage resetPage = new ResetPasswordPage
            {
                BindingContext = reset
            };
            Application.Current.MainPage.Navigation.PushAsync(resetPage);
        }



        private async Task FingerAuth()
        {
            var password = Storage.GetKeyValue("password");
            if (String.IsNullOrEmpty(password))
            {
                //advise user that they must sign in with user name and password before they can use touch id
                await Application.Current.MainPage.DisplayAlert("Login", "You must login with email and password.", "Ok");
            }

            Login loginModel = new Login();
            loginModel.UserName = Storage.GetKeyValue("username");
            loginModel.Password = password;
            loginModel.Token = String.Empty;

            var request = new AuthenticationRequestConfiguration("Login with Touch ID", "Login with Touch ID");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                // get authenicated to get token id back
                var b = await LoginPost(loginModel);

                if (b == true)
                {
                    //move into setup sequence if not done before
                    if (loginModel.SetupComplete == "Complete")
                    {
                        SetupWelcomePage welcomePage = new SetupWelcomePage();
                        SetupWelcomePageViewModel welcomeViewModel = new SetupWelcomePageViewModel();
                        welcomePage.BindingContext = welcomeViewModel;
                        await Application.Current.MainPage.Navigation.PushAsync(welcomePage);
                    }
                    else
                    {
                        var feed = new FeedTabbedPage();
                        var vm = new FeedTabbedPageViewModel("news");
                        feed.BindingContext = vm;
                        await Application.Current.MainPage.Navigation.PushAsync(feed);
                    }
                }

            }
            else
            {
                // not allowed to do secret stuff

            }
        }
        #endregion

        #region Commands
        private async void LoginAction()
        {
            ResponseMessage = String.Empty;
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                ResponseMessage = "Email and/or Password is required.";
                return;
            }
            await ValidateLogin();
        }

        private void ResetPasswordAction()
        {
            ResetPassword();
        }

        private async void EnableSecurityAction()
        {
            UserEmail = String.Empty;
            Password = String.Empty;
            await FingerAuth();
        }

        #endregion



    }
}
