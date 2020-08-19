using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupPickOurPicPageViewModel : INotifyPropertyChanged

    {
        #region Fields
        private string _imageFile;
        #endregion

        #region Properties
        public string ImageFile
        {
            get
            {
                return _imageFile;
            }
            set
            {
                _imageFile = value;
                OnPropertyChanged(nameof(ImageFile));
            }
        }
        public string UserId { get; set; }
        #endregion

        #region Delegates
        private readonly DelegateCommand mSelectPictureCommand;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor

        public SetupPickOurPicPageViewModel()
        {
            UserId = Storage.GetKeyValue("UserId");
            mSelectPictureCommand = new DelegateCommand(SelectPictureCommand, CanExecuteCommand);
        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private async void SelectPictureCommand(object commandParameter)
        {
            ProfileRecord profile = new ProfileRecord();
            string UserName = Storage.GetKeyValue("username");
            string Password = Storage.GetKeyValue("password");
            profile.volPicture = ImageFile;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/updatepicture", content);
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

            //TODO pass the new profile pic back to SetupProfilePicPage
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}