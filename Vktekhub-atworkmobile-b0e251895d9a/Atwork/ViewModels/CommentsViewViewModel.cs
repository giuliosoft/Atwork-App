using Atwork.Commands;
using Atwork.Helpers;
using Atwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class CommentsViewViewModel
    {
        #region 
        public string NewsTitle { get; set; }
        ObservableCollection<object> ViewList;
        #endregion

        #region Delegates
        public Command LoadCommentsCommand { get; }
        public Command AddCommentCommand { get; }
        #endregion

        #region Contructor
        public CommentsViewViewModel(string area, string id)
        {
            //await GetAreaComments(area, id);
            LoadCommentsCommand = new Command(LoadCommentsAction);
            AddCommentCommand = new Command(AddCommentAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Action
        private void LoadCommentsAction()
        {

        }

        private void AddCommentAction()
        {
            //add
        }

        private async Task GetAreaComments(string area, string id)
        {
            await GetComments(area, id);
        }
        #endregion

        #region Private Methods
        //id is news or activity id
        private async Task GetComments(string area, string id)
        {
            if(area == "news")
            {

                using (HttpClient client = new HttpClient())
                {
                    string token = Storage.GetKeyValue("token");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    string url = $"https://app.atwork.ai/api/commentslikes/getlist/{id}/";
                    HttpResponseMessage response = await client.GetAsync(url);

                    //string reason = response.ReasonPhrase;

                    if (response.IsSuccessStatusCode)
                    {
                        string s = await response.Content.ReadAsStringAsync();
                        NewsComment result = new NewsComment();
                        result = JsonConvert.DeserializeObject<NewsComment>(s);

                    }
                }
            }
            
        }
        #endregion
    }
}
