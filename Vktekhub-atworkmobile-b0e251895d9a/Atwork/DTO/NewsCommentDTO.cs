namespace Atwork.DTO
{
    using Newtonsoft.Json;
    public partial class NewsCommentDTO
    {
        
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("coUniqueId")]
        public string coUniqueID { get; set; }

        [JsonProperty("newsUniqueId")]
        public string newsUniqueID { get; set; }

        [JsonProperty("comById")]
        public string comByID { get; set; }

        [JsonProperty("comDate")]
        public string comDate { get; set; }

        [JsonProperty("comComment")]
        public string comContent { get; set; }

    }
}
