using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atwork.DTO
{
    public class NewsItemDTO
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("couniqueid")]
        public string coUniqueID { get; set; }

        [JsonProperty("newsuniqueid")]
        public string newsUniqueID { get; set; }

        [JsonProperty("voluniqueid")]
        public string volUniqueID { get; set; }

        [JsonProperty("newstitle")]
        public string newsTitle { get; set; }

        [JsonProperty("newcontent")]
        public string newsContent { get; set; }

        [JsonProperty("newsdatetime")]
        public string newsDateTime { get; set; }

        [JsonProperty("newpostedtime")]
        public string newsPostedTime { get; set; }

        [JsonProperty("newsprivacy")]
        public string newsPrivacy { get; set; }

        [JsonProperty("newsstatus")]
        public string newsStatus { get; set; }

        [JsonProperty("newsorigin")]
        public string newsOrigin { get; set; }

        [JsonProperty("newsimage")]
        public string newsImage { get; set; }

        [JsonProperty("newsfile")]
        public string newsFile { get; set; }

        [JsonProperty("newsfileoriginal")]
        public string newsFileOriginal { get; set; }
    }
}
