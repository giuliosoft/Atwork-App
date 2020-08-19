using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    
    public class SetupInterestsPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<string> InterestsList { get; set; }
        public MobilePreference m;
        #endregion

        #region Delegates
        public Command SaveInterestsCommand;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor
        public SetupInterestsPageViewModel(MobilePreference mobilePreference)
        {
            m = mobilePreference;
            //TODO what is our data source?
            GetInterestList();
            SaveInterestsCommand = new Command(SaveInterestsAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private async void SaveInterestsAction(object commandParameter)
        {
            List<VolunteerInterest> interests = new List<VolunteerInterest>();
            foreach(var item in InterestsList)
            {
                VolunteerInterest vol = new VolunteerInterest();
                vol.volUniqueID = Storage.GetKeyValue("UserId");
                vol.volInterest = item;
                interests.Add(vol);
            }

            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(interests), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/insertinterests", content);
                if (response.IsSuccessStatusCode)
                {
                    SetupInterestsPageViewModel setupInterestsPageViewModel = new SetupInterestsPageViewModel(m);
                    SetupInterestsPage setupInterestsPage = new SetupInterestsPage();
                    setupInterestsPage.BindingContext = setupInterestsPageViewModel;
                    await Application.Current.MainPage.Navigation.PushAsync(setupInterestsPage);

                }
                else
                {
                    //ResponseMessage 
                }

            }

        }
        #endregion

        #region Private Methods
        private async void GetInterestList()
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                //string token = Storage.GetKeyValue("token");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                HttpResponseMessage response = await client.GetAsync("https://app.atwork.ai/api/common/getinterestlist");
                if (response.IsSuccessStatusCode)
                { 
                    string s = await response.Content.ReadAsStringAsync();
                    List<MobileInterest> result = new List<MobileInterest>();
                    result = JsonConvert.DeserializeObject<List<MobileInterest>>(s);
                    foreach (var item in result)
                    {
                        InterestsList.Add(item.Interest);
                    }
                }
            }
            
        }
        #endregion
    }
}
