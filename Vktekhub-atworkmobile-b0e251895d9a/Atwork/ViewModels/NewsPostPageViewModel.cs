using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Atwork.ViewModels
{
    public class NewsPostPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _fullName;
        private string _avatarImage;
        private string _likesImage;
        private string _postTitle;
        private string _postImage;
        private string _postContent;
        private string _postFile;
        #endregion

        #region Properties
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string AvatarImage
        {
            get
            {
                return _avatarImage;
            }
            set
            {
                _avatarImage = value;
                OnPropertyChanged(nameof(AvatarImage));
            }
        }

        public string LikesImage
        {
            get
            {
                return _likesImage;
            }
            set
            {
                _likesImage = value;
                OnPropertyChanged(nameof(LikesImage));
            }
        }

        public string PostTitle
        {
            get
            {
                return _postTitle;
            }
            set
            {
                _postTitle = value;
                OnPropertyChanged(nameof(PostTitle));
            }
        }

        public string PostImage
        {
            get
            {
                return _postImage;
            }
            set
            {
                _postImage = value;
                OnPropertyChanged(nameof(PostImage));
            }
        }

        public string PostContent
        {
            get
            {
                return _postContent;
            }
            set
            {
                _postContent = value;
                OnPropertyChanged(nameof(PostContent));
            }
        }

        public string PostFile
        {
            get
            {
                return _postFile;
            }
            set
            {
                _postFile = value;
                OnPropertyChanged(nameof(PostFile));
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
        public Command OpenFileCommand { get; }
        #endregion

        #region Contructor
        // action is passed in as "add" "view" "edit" or "delete" for page mode
        public NewsPostPageViewModel(string action, string id)
        {

            // get the news post record
            if (action == "view" || action == "delete")
            {
                GetPost(id);
            }

            //open the file attachment
            OpenFileCommand = new Command(OpenFileAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Actions
        private void OpenFileAction()
        {

        }

        private async void GetPost(string id)
        {
            await GetNewsPost(id);
        }


        #endregion

        #region Private Methods
        private async Task GetNewsPost(string id)
        {
            using (var client = new HttpClient())
            {
                string UserName = Storage.GetKeyValue("username");
                string Password = Storage.GetKeyValue("password");

                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                HttpResponseMessage response = await client.GetAsync($"https://app.atwork.ai/api/news/getlist/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    VolunteerNewsItem result = new VolunteerNewsItem();
                    result = JsonConvert.DeserializeObject<VolunteerNewsItem>(s);

                    FullName = $"{result.volFirstName} {result.volLastName}";
                    //TODO need posted by image
                    AvatarImage = result.volPicture; 
                    //TODO add LikesImage to query or another api call
                    PostTitle = result.newsTitle;
                    PostImage = result.newsImage;
                    PostContent = result.newsContent;
                    PostFile = result.newsFile;
                }
            }
        }

        
        #endregion
    }
}

