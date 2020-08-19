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
    public class SetupAboutMePageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _aboutMe;
        #endregion

        #region Properties
        public string UserName { get; set; }
        public MobilePreference m;
        public string AboutMe
        {
            get
            {
                return _aboutMe;
            }
            set
            {
                _aboutMe = value;
                OnPropertyChanged(nameof(AboutMe));
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
        public Command SaveAboutMeCommand { get; }
        #endregion

        #region Contructor

        public SetupAboutMePageViewModel(MobilePreference mobilePreference)
        {
            m = mobilePreference;
            SaveAboutMeCommand = new Command(SaveAboutMeAction);
        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private async void SaveAboutMeAction()
        {
            await SaveAboutMe();
        }
        #endregion

        #region Private Methods
        private async Task SaveAboutMe()
        {
            //send ajax post to API LoginController
            ProfileRecord profile = new ProfileRecord();
            profile.volEmail = Storage.GetKeyValue("useremail");
            profile.volAbout = AboutMe;

            using (var client = new HttpClient())
            {
                //string token = Storage.GetKeyValue("token");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/aboutme", content);
                if (response.IsSuccessStatusCode)
                {
                    SetupInterestsPageViewModel setupInterestsPageViewModel = new SetupInterestsPageViewModel(m);
                    SetupInterestsPage setupInterestsPage = new SetupInterestsPage();
                    setupInterestsPage.BindingContext = setupInterestsPageViewModel;
                    await Application.Current.MainPage.Navigation.PushAsync(setupInterestsPage);

                }
                else
                {
                    //login failed
                    //ResponseMessage = $"Login Failed. Status Code: {response.StatusCode}";
                }

            }

        }
        #endregion
    }
}
