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
    public class ActivityDetailPageViewModel : INotifyPropertyChanged
    {
        #region Field
        private string _numberJoined;
        private string _description;
        private string _minGroupSize;
        private string _maxGroupSize;
        private string _activityTime;
        private string _coveredByCompany;
        private string _price;
        private string _language;
        private string _otherDates;
        private string _activityType;
        private string _skills;
        private string _specialRequirements;
        private string _orgName;
        private string _orgAddress;
        #endregion

        #region Properties
        public string NumberJoined
        {
            get
            {
                return _numberJoined;
            }
            set
            {
                _numberJoined = value;
                OnPropertyChanged(nameof(_numberJoined));
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(_description));
            }
        }
        
        public string MinGroupSize
        {
            get
            {
                return _minGroupSize;
            }
            set
            {
                _minGroupSize = value;
                OnPropertyChanged(nameof(_minGroupSize));
            }
        }
        public string MaxGroupSize
        {
            get
            {
                return _maxGroupSize;
            }
            set
            {
                _maxGroupSize = value;
                OnPropertyChanged(nameof(_maxGroupSize));
            }
        }
        public string ActivityTime
        {
            get
            {
                return _activityTime;
            }
            set
            {
                _activityTime = value;
                OnPropertyChanged(nameof(_activityTime));
            }
        }
        public string CoveredByCompany
        {
            get
            {
                return _coveredByCompany;
            }
            set
            {
                _coveredByCompany = value;
                OnPropertyChanged(nameof(_coveredByCompany));
            }
        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(_price));
            }
        }
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged(nameof(_language));
            }
        }
        public string OtherDates
        {
            get
            {
                return _otherDates;
            }
            set
            {
                _otherDates = value;
                OnPropertyChanged(nameof(_otherDates));
            }
        }
        public string ActivityType
        {
            get
            {
                return _activityType;
            }
            set
            {
                _activityType = value;
                OnPropertyChanged(nameof(_activityType));
            }
        }
        public string Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                OnPropertyChanged(nameof(_skills));
            }
        }
        public string SpecialRequirements
        {
            get
            {
                return _specialRequirements;
            }
            set
            {
                _specialRequirements = value;
                OnPropertyChanged(nameof(_specialRequirements));
            }
        }
        public string OrgName
        {
            get
            {
                return _orgName;
            }
            set
            {
                _orgName = value;
                OnPropertyChanged(nameof(_orgName));
            }
        }
        public string OrgAddress
        {
            get
            {
                return _orgAddress;
            }
            set
            {
                _orgAddress = value;
                OnPropertyChanged(nameof(_orgAddress));
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
        public Command LoadActivityCommand;
        public Command PositionChangedCommand;
        #endregion

        #region Contructor

        public ActivityDetailPageViewModel()
        {
            LoadActivityCommand = new Command(LoadActivityAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Events
        
        #endregion

        #region Commands
        private async void LoadActivityAction()
        {
            string id = string.Empty;
            await GetActivity(id);
        }

        #endregion

        #region Private Methods
        private async Task GetActivity(string id)
        {
            
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                HttpResponseMessage response = await client.GetAsync($"https://app.atwork.ai/api/activites/getrow/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    List<Activity> result = new List<Activity>();
                    result = JsonConvert.DeserializeObject<List<Activity>>(s);

                    //stuff

                }
            }
        }



        private async Task GetActivityCategories(string id)
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                HttpResponseMessage response = await client.GetAsync("https://app.atwork.ai/api/");
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    //List<T> result = new List<T>();
                    //result = JsonConvert.DeserializeObject<List<T>>(s);

                    //stuff

                }
            }
        }
        #endregion
    }
}
