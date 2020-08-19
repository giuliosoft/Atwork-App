using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Atwork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPickCameraRollPage : ContentPage
    {
        public SetupPickCameraRollPage()
        {
            InitializeComponent();

            buttonChoosePicture.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos", "Permission not granted to photos.", "Cancel");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null) return;

                imageProfile.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                }
                );
            };
        }

    }
}