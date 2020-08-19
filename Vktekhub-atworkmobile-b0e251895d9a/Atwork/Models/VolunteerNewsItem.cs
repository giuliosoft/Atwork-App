using System;
using System.Collections.Generic;
using System.Text;

namespace Atwork.Models
{
    public class VolunteerNewsItem
    {
        public int id { get; set; }
        public string coUniqueID { get; set; }
        public string newsUniqueID { get; set; }
        public string volUniqueID { get; set; }
        public string newsTitle { get; set; }
        public string newsContent { get; set; }
        public DateTime? newsDateTime { get; set; }
        public string newsPostedTime { get; set; }
        public string newsPrivacy { get; set; }
        public string newsStatus { get; set; }
        public string newsOrigin { get; set; }
        public string coName { get; set; }
        public string volFirstName { get; set; }
        public string volLastName { get; set; }
        public string newsImage { get; set; }
        public string newsFile { get; set; }
        public string volPicture { get; set; }
        public string newsFileOriginal { get; set; }
    }
}
