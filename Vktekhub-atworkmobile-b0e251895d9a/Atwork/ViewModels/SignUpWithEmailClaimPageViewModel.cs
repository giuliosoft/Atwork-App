using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    class SignUpWithEmailClaimPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _onBoarded;
        #endregion

        #region Properties
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Delegates
        public Command ClaimCommand { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Contructor

        public SignUpWithEmailClaimPageViewModel(Login login)
        {
            var profile = GetTheProfileRecord(login);
            
            ClaimCommand = new Command(ClaimAction);
            CancelCommand = new Command(CancelAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private void ClaimAction()
        {
            string savedUserName = Storage.GetKeyValue("username");
            string savedPassword = Storage.GetKeyValue("password");
            if (_onBoarded == "Complete")
            {
                Storage.SetKeyValue("setupcomplete", _onBoarded);
                LoginEntryPageViewModel vm = new LoginEntryPageViewModel();
                LoginEntryPage pg = new LoginEntryPage();
                pg.BindingContext = vm;
                Application.Current.MainPage.Navigation.PushAsync(pg);
            }

            if (String.IsNullOrEmpty(savedPassword))
            {
                SignUpPasswordPageViewModel pass = new SignUpPasswordPageViewModel();
                SignUpPasswordPage passPage = new SignUpPasswordPage();
                passPage.BindingContext = pass;
                Application.Current.MainPage.Navigation.PushAsync(passPage);
            }
            else
            {
                
            }
        }

        private void CancelAction()
        {
            //TODO raise alert

            //remove this page from the nav stack
            Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region Private Methods
        public async Task GetTheProfileRecord(Login login)
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = "signup";
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));

                HttpResponseMessage response = await client.GetAsync($"https://app.atwork.ai/api/profiles/getrow");
                string reason = response.ReasonPhrase;

                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    ProfileRecord result = new ProfileRecord();
                    result = JsonConvert.DeserializeObject<ProfileRecord>(s);

                    FullName = $"{result.volFirstName} {result.volLastName}";
                    Email = result.volEmail;
                    Department = result.volDepartment;
                    //TODO there is no job title field
                    JobTitle = string.Empty;
                    _onBoarded = result.volOnBoardStatus;
                    Storage.SetKeyValue("setupcomplete", _onBoarded);

                }
            }
        }
        #endregion
    }
}
