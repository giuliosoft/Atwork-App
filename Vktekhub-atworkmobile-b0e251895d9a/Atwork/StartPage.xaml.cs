using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atwork.Helpers;
using Atwork.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atwork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            BindingContext = new StartPageViewModel();
            string imgUrl = "http://engage.atwork.ai/upload/mobile/ATWORK_LOGO_GRAY.png";
            logoImage.Source = ImageSource.FromUri(new Uri(imgUrl));
        }
    }
}