using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Atwork.Helpers;

namespace Atwork.Models
{
    public partial class CombinedNewsItem 
    {
        public int id { get; set; }
        public string coUniqueID { get; set; }
        public string newsUniqueID { get; set; }
        public string volUniqueID { get; set; }
        public string newsTitle { get; set; }
        public string newsContent { get; set; }
        public DateTime? newsDateTime { get; set; }
        public DateTime? newsPostedTime { get; set; }
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

        public string SubstringNewsContent
        {
            get
            {
                var s = string.Empty;
                if(newsContent.Length > 150) 
                {
                    s = $"{newsContent.Substring(0, 200)} ...";
                }
                else
                {
                    s = newsContent;
                }
                return s;
            }
        }
        public string FullName
        {
            get
            {
                string s = String.Empty;
                if(volLastName == "N.A.")
                {
                    s = "NEWS";
                }
                else
                {
                    s = $"{volFirstName} {volLastName}";
                }
                return s;
            }
        }

        public string VolPicturePath
        {
            get
            {
                return $"{ImagesHelper.EmployeeAvatarPath}{volPicture}";
            }
        }

        public string NewsImagePath
        {
            get
            {
                return $"{ImagesHelper.NewsImagesPath}{newsImage}";
            }
        }

        public string PostAging
        {
            get
            {
                string returnVal = String.Empty;

                if (newsPostedTime.HasValue)
                {
                    DateTime dt = DateTime.Now;
                    DateTime posted = (DateTime) newsPostedTime;
                    TimeSpan diff = dt.Subtract(posted);
                    if (diff.TotalHours >= 1 && diff.TotalHours < 24)
                    {
                        returnVal = $"{diff.TotalHours.ToString("###")} hours ago";
                    }
                    else if(diff.TotalHours >= 24)
                    {
                        returnVal = $"{diff.TotalDays.ToString("###")} days ago";
                    }
                    else
                    {
                        returnVal = $"{diff.TotalMinutes.ToString("###")} mins ago";
                    }
                }

                if (String.IsNullOrEmpty(returnVal))
                {
                    return String.Empty;
                }

                return returnVal;
            }
        }

        
    }
}
