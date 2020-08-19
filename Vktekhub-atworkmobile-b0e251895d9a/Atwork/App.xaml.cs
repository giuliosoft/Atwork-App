using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


namespace Atwork
{
    public partial class App : Application
    {
        public static string apiUrl = string.Empty;

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3NDM5QDMxMzgyZTMxMmUzMFpzMmlxV0pZOHV3eG15VVBIZ3BwQlI1L1hVTjM1ZUhTMCtsSHlIR3VtY2s9");

            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //AppCenter.Start("ios=e5a764cb-f4a4-47f6-b224-57d248fe415f;", typeof(Analytics), typeof(Crashes));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
