using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupPickCameraRollPageViewModel : INotifyPropertyChanged

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
        public MobilePreference m;
        #endregion

        #region Delegates
        public Command SelectPictureCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor
        public SetupPickCameraRollPageViewModel()
        {
            
            UserId = Storage.GetKeyValue("UserId");
            SelectPictureCommand = new Command(SelectPictureAction);
        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private async void SelectPictureAction()
        {
            ProfileRecord profile = new ProfileRecord();
            //profile.coUniqueID = UserId;
            profile.volPicture = ImageFile;

            //update picture to database
            await SaveImage(profile);

            SetupAboutMePageViewModel setupVM = new SetupAboutMePageViewModel(m);
            SetupAboutMePage aboutMePage = new SetupAboutMePage();
            aboutMePage.BindingContext = setupVM;
            await Application.Current.MainPage.Navigation.PushAsync(aboutMePage);
        }

        #endregion

        #region Private Methods
        private async Task SaveImage(ProfileRecord profile)
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/profiles/updatepicture", content);
                if (response.IsSuccessStatusCode)
                {
                    //success stuff
                }
                else
                {
                    //ResponseMessage 
                }

            }
        }

        private async Task UpdateOnBoard(ProfileRecord profile)
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://app.atwork.ai/api/", content);
                if (response.IsSuccessStatusCode)
                {
                    //success stuff
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
