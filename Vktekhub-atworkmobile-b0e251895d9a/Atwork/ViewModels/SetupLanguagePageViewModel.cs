using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupLanguagePageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _selectedLanguage;
        #endregion

        #region Properties
        public MobilePreference m;

        
        public string SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        ObservableCollection<Language> languages = new ObservableCollection<Language>();
        public ObservableCollection<Language> Languages { get { return languages; } }

        #endregion

        #region Delegates
        public Command SelectLanguageCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public SetupLanguagePageViewModel(MobilePreference mobilePreference)
        {
            languages.Add(new Language { LanguageValue = "English" });
            languages.Add(new Language { LanguageValue = "German" });
            languages.Add(new Language { LanguageValue = "French" });
            languages.Add(new Language { LanguageValue = "Italian" });

            SelectLanguageCommand = new Command(SelectLanguageAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private async void SelectLanguageAction()
        {
            Storage.SetKeyValue("language", SelectedLanguage);
            ProfileRecord profile = new ProfileRecord();
            string UserName = Storage.GetKeyValue("username");
            string Password = Storage.GetKeyValue("password");
            profile.volEmail = UserName;
            profile.volLanguage = SelectedLanguage;

            using (var client = new HttpClient())
            {
                //string token = Storage.GetKeyValue("token");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/updatelanguage", content);
                if (response.IsSuccessStatusCode)
                {
                    //TODO pass model to next step of setup
                    SetupProfilePicPageViewModel setupProfilePicPageViewModel = new SetupProfilePicPageViewModel();
                    SetupProfilePicPage setupProfilePicPage = new SetupProfilePicPage();
                    setupProfilePicPage.BindingContext = setupProfilePicPageViewModel;
                    await Application.Current.MainPage.Navigation.PushAsync(setupProfilePicPage);
                }
                else
                {
                    //ResponseMessage 
                }

            }

        }
        #endregion
    }
}
