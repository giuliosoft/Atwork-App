using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class ResetPasswordPageViewModel : BaseViewModel
    {
        #region Fields
        private string _userName;
        private string _oldPassword;
        private string _newPassword;
        #endregion

        #region Properties
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        #endregion

        #region Delegates
        public Command SubmitResetCommand;
        #endregion

        #region Constructors
        public ResetPasswordPageViewModel()
        {
            SubmitResetCommand = new Command(SubmitResetAction);
        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Actions
        private void SubmitResetAction()
        {
            SubmitReset();
        }
        #endregion

        #region Private Methods
        private async void SubmitReset()
        {
            //need to resubmit validate user to get new token
            Login loginModel = new Login();
            loginModel.UserName = Storage.GetKeyValue("username");
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = OldPassword;
                client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                object result = await Helpers.HttpClientHelper.PostApi("/api/login/resetpassword", loginModel);
                
                var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/login/resetpassword", content);
                if (response.IsSuccessStatusCode)
                {
                    //TODO add page navigation

                    //SetupProfilePicPageViewModel setupProfilePicPageViewModel = new SetupProfilePicPageViewModel();
                    //SetupProfilePicPage setupProfilePicPage = new SetupProfilePicPage();
                    //setupProfilePicPage.BindingContext = setupProfilePicPageViewModel;
                    //await Application.Current.MainPage.Navigation.PushAsync(setupProfilePicPage);
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
