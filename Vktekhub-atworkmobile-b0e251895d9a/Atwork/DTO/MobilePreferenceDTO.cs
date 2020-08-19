using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Atwork.DTO
{
    public class MobilePreferenceDTO
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("profileuniqueid")]
        public string ProfileUniqueID { get; set; }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("deviceid")]
        public string DeviceId { get; set; }

        [JsonProperty("lastsessiondate")]
        public string LastSessionDate { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("sessiontoken")]
        public string SessionToken { get; set; }

        [JsonProperty("setupcomplete")]
        public string SetupComplete { get; set; }

        [JsonProperty("allownotifications")]
        public int AllowNotifications { get; set; }
    }
}
