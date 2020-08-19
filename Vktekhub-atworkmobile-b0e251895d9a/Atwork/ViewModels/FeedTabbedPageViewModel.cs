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
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class FeedTabbedPageViewModel : INotifyPropertyChanged
    {
        //#region Properties
        //public string HeaderTitle { get; set; }
        //public string NewsItemHeaderTitle { get; set; }
        //public string ActivityHeaderTitle { get; set; }
        //public string CompanyId { get; set; } //might not need

        //public List<ActivityFeed> ActivityFeedList { get; set; }
        public List<CombinedNewsItem> NewsFeedList { get; set; }
        //#endregion

        //#region Delegates
        //public Command LoadActivityCommand { get; set; }
        //public Command LoadNewsCommand { get; set; }
        //public Command OpenNewsCommand { get; set; }
        //public Command OpenActivityCommand { get; set; }
        //public Command AddActivityCommand { get; set; }
        public Command AddNewsCommand { get; set; }
        //public Command NewsMenuCommand { get; set; }
        //#endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor

        public FeedTabbedPageViewModel(string feedMode)
        {
            
            //LoadActivityAction();
            
            LoadNewsAction();
            
            //LoadActivityCommand = new Command(LoadActivityAction);
            //LoadNewsCommand = new Command(LoadNewsAction);
            //OpenNewsCommand = new Command(OpenNewsAction);
            //OpenActivityCommand = new Command(OpenActivityAction);
            //AddActivityCommand = new Command(AddActivityAction);
            AddNewsCommand = new Command(AddNewsAction);
            //NewsMenuCommand = new Command(NewsMenuAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        //#region News Commands

        //private void NewsMenuAction()
        //{
        //    //open pop up drawer at the bottom of form, with "Edit" and "Delete" buttons

        //}

        private async void LoadNewsAction()
        {
            string id = Helpers.Storage.GetKeyValue("companyid");

            using (var client = new HttpClient())
            {
                try
                {
                    string UserName = Storage.GetKeyValue("username");
                    string Password = Storage.GetKeyValue("password");
                    client.DefaultRequestHeaders.Authorization =
                                        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
                    string url = $"https://app.atwork.ai/api/news/getlist/{id}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string s = await response.Content.ReadAsStringAsync();
                        //List<CombinedNewsItem> items = new List<CombinedNewsItem>();
                        NewsFeedList = JsonConvert.DeserializeObject<List<CombinedNewsItem>>(s);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        //private async void OpenNewsAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //    NewsPostPageViewModel vm = new NewsPostPageViewModel("view", id);
        //    NewsPostPage pg = new NewsPostPage();
        //    pg.BindingContext = vm;
        //    await Application.Current.MainPage.Navigation.PushAsync(pg);
        //}
        //private async void DeleteNewsAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //    NewsPostPageViewModel vm = new NewsPostPageViewModel("delete", id);
        //    NewsPostPage pg = new NewsPostPage();
        //    pg.BindingContext = vm;
        //    await Application.Current.MainPage.Navigation.PushAsync(pg);
        //}
        private async void AddNewsAction()
        {
            string id = Helpers.Storage.GetKeyValue("companyid");
            NewsPostPageViewModel vm = new NewsPostPageViewModel("add", id);
            NewsPostPage pg = new NewsPostPage();
            pg.BindingContext = vm;
            await Application.Current.MainPage.Navigation.PushAsync(pg);
        }
        //private async void EditNewsAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //    NewsPostPageViewModel vm = new NewsPostPageViewModel("edit", id);
        //    NewsPostPage pg = new NewsPostPage();
        //    pg.BindingContext = vm;
        //    await Application.Current.MainPage.Navigation.PushAsync(pg);
        //}
        //#endregion

        //#region Activity Actions
        //private async void LoadActivityAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");

        //    using (var client = new HttpClient())
        //    {
        //        //string token = Storage.GetKeyValue("token");
        //        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //        string UserName = Storage.GetKeyValue("username");
        //        string Password = Storage.GetKeyValue("password");
        //        client.DefaultRequestHeaders.Authorization =
        //                            new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
        //        HttpResponseMessage response = await client.GetAsync($"https://app.atwork.ai/api/activities/getlist/{id}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string s = await response.Content.ReadAsStringAsync();
        //            ActivityFeedList = JsonConvert.DeserializeObject<List<ActivityFeed>>(s);
        //        }
        //    }
        //}
        //private void AddActivityAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //}
        //private void OpenActivityAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //}
        //private void EditActivityAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //}
        //private void DeleteActivityAction()
        //{
        //    string id = Helpers.Storage.GetKeyValue("companyid");
        //}
        //#endregion

        //#region Private Methods

        //#endregion
    }
}
