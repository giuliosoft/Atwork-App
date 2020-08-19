
using System;
using Atwork.Helpers;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class StartPageViewModel //: INotifyPropertyChanged
    {
        #region Properties
        //public string LogoImage { get; set; }
        #endregion

        #region Delegates
        public Command LoginCommand { get; }
        public Command SignupCommand { get; }
        #endregion

        #region Constructor
        public StartPageViewModel()
        {
            LoginCommand = new Command(LoginActionAsync);
            SignupCommand = new Command(SignupAction);
            
        }
        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Events
    
        #endregion

        #region Commands
        public async void LoginActionAsync()
        {
            
            try
            {
                LoginEntryPageViewModel vm = new LoginEntryPageViewModel();
                LoginEntryPage pg = new LoginEntryPage();
                pg.BindingContext = vm;
                await Application.Current.MainPage.Navigation.PushAsync(pg);
            }
            catch(Exception ex)
            {

            }
            
        }

        public async void SignupAction()
        {
            SignUpWelcomePageViewModel vm = new SignUpWelcomePageViewModel();
            SignUpWelcomePage pg = new SignUpWelcomePage();
            pg.BindingContext = vm;
            await Application.Current.MainPage.Navigation.PushAsync(pg);
        }

        
        #endregion
    }
}
