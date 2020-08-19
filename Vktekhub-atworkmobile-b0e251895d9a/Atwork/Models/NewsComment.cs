namespace Atwork.Models
{
    using System;

    public partial class NewsComment
    {
        
        public int Id { get; set; }
        public string coUniqueID { get; set; }
        public string newsUniqueID { get; set; }
        public string comByID { get; set; }
        public DateTime? comDate { get; set; }
        public string comContent { get; set; }
    }
}
