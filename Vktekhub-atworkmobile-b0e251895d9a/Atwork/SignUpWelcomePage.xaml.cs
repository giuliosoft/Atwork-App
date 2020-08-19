using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atwork.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atwork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpWelcomePage : ContentPage
    {
        public SignUpWelcomePage()
        {
            InitializeComponent();
            logoImage.Source = $"{ImagesHelper.MobileImagesPath}ATWORK_LOGO_GRAY.png";
        }
    }
}