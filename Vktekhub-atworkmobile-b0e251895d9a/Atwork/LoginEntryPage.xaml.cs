using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Atwork.Helpers;
using Atwork.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atwork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginEntryPage : ContentPage
    {
        public LoginEntryPage()
        {
            InitializeComponent();

            //try
            //{
            //    string imgUrl = "http://engage.atwork.ai/upload/mobile/ATWORK_LOGO_GRAY.png";
            //    logoImage.Source = ImageSource.FromUri(new Uri(imgUrl));
            //}
            //catch (Exception ex)
            //{

            //}

        }

        
        
    }
}