using Atwork.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atwork.Helpers
{
    public class HttpClientHelper
    {
        //private static string baseUrl { get => "https://app.atwork.ai"; }

        //params
        //contentModel = the FromBody content sending in the Post command, name of a json model class
        public static async Task<object> PostApi(string apiUrl, object contentModel)
        {
            object returnObject = null;
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(baseUrl);
                string token = Storage.GetKeyValue("token");
                client.DefaultRequestHeaders
                                .Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);                 
                //serialize the model
                var content = new StringContent(JsonConvert.SerializeObject(contentModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    returnObject = JsonConvert.DeserializeObject(s);
                }
                
                return returnObject;
            }
        }

        //params
        //urlParam = the string param(s) sending in the Get url
        //returnObject = the model class expected to return as json from the post, name of a model class
        public static async Task<dynamic> GetApi(string apiUrl, Type returnType)
        {
            using (var client = new HttpClient())
            {
                dynamic returnObject = null;
                string token = Storage.GetKeyValue("token");
                client.DefaultRequestHeaders
                                .Accept
                                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string s = await response.Content.ReadAsStringAsync();
                    
                    returnObject = JsonConvert.DeserializeAnonymousType(s, returnType);
                }

                return returnObject;
            }
        }

        
    }

    
}
