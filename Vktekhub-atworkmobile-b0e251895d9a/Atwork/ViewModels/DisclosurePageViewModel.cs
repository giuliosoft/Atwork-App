using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class DisclosurePageViewModel : INotifyPropertyChanged
    {


        #region Properties
        public string Disclaimer { get; set; }
        public string Terms { get; set; }
        public string DisclosureText { get; set; }
        public int AcceptedDisclaimer { get; set; }
        public int AcceptedTerms { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Delegates
        public Command AcceptDisclaimerCommand { get; }
        public Command AcceptTermsCommand { get; }
        #endregion

        #region Contructor

        public DisclosurePageViewModel()
        {
            //GetDisclosures();
            AcceptDisclaimerCommand = new Command(AcceptDisclaimerAction);
            AcceptTermsCommand = new Command(AcceptTermsAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private async void AcceptDisclaimerAction()
        {
            await SetDisclosureAcceptance();
        }
        private void AcceptTermsAction()
        {
            
        }
        #endregion

        #region Private Methods
        private async Task GetDisclosures()
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                HttpResponseMessage response = await client.GetAsync($"https://app.atwork.ai/api/profiles/getrow");
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    ProfileRecord result = new ProfileRecord();
                    result = JsonConvert.DeserializeObject<ProfileRecord>(s);
                    DisclosureText = string.Empty; 

                }
            }
            
        }

        private async Task SetDisclosureAcceptance()
        {
            MobilePreference mobilePreference = new MobilePreference();
            mobilePreference.UserEmail = Storage.GetKeyValue("username");
            mobilePreference.DisclosureDate = DateTime.Now.ToShortDateString();
            mobilePreference.AcceptedDisclosure = 1;
            dynamic result = await Helpers.HttpClientHelper.PostApi("/api/mobilepreference/acceptdisclosure", mobilePreference);
        }

        #endregion
    }
}

