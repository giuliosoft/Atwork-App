using System;
namespace Atwork.Helpers
{
    public class ImagesHelper
    {
        public static string EmployeeAvatarPath
        {
            get
            {
                return "http://voluntycorporate.atlasics.com/employee/employee_images/";
            }
        }
        public static string EmployeeImagesPath
        {
            get
            {
                return "http://voluntycorporate.atlasics.com/employee/upload/empPictures/";
                //return "https://engage.atwork.ai/employee/upload/empPictures/";
            }
        }

        public static string OtherImagesPath
        {
            get
            {
                //return "https://engage.atwork.ai/upload/photos/";
                return "http://voluntycorporate.atlasics.com/upload/photos/";
            }
        }
        
        public static string MobileImagesPath
        {
            get
            {
                return "https://engage.atwork.ai/upload/mobile/";
            }
        }

        public static string ActivityImagesPath
        {
            get
            {
                //return "https://engage.atwork.ai/upload/images/activities/";
                return "http://voluntycorporate.atlasics.com/upload/images/activities/";
            }
        }

        public static string NewsImagesPath
        {
            get
            {
                //return "https://engage.atwork.ai/employee/upload/newsitems/";
                return "http://voluntycorporate.atlasics.com/employee/upload/newsitems/";
            }
        }


    }
}
