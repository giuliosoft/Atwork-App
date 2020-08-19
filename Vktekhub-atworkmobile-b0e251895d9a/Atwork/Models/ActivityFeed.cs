using Atwork.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atwork.Models
{
    public class ActivityFeed
    {
        public string id { get; set; }
        public string proTitle { get; set; }
        public string coUniqueID { get; set; }
        public string proCompany { get; set; }
        public string proDescription { get; set; }
        public string proLocation { get; set; }
        public string proCategoryName { get; set; }
        public string proSubCategoryName { get; set; }
        public string proStatus { get; set; }
        public string proPartner { get; set; }
        public string proAddActivity_HoursCommitted { get; set; }
        public string proAddActivity_StartTime { get; set; }
        public string proAddActivity_EndTime { get; set; }
        public string proAddActivity_ParticipantsMinNumber { get; set; }
        public string proAddActivity_ParticipantsMaxNumber { get; set; }
        public string proBackgroundImage { get; set; }
    
        public string SubstringActivityContent
        {
            get
            {
                var s = string.Empty;
                if (proDescription.Length > 150)
                {
                    s = $"{proDescription.Substring(0, 150)} ...";
                }
                else
                {
                    s = proDescription;
                }
                return s;
            }
        }

        public string ActivityPicturePath
        {
            get
            {
                return $"{ImagesHelper.ActivityImagesPath}{proBackgroundImage}";
            }
        }
    }
}
