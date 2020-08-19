using Atwork.Commands;
using Atwork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupWelcomePageViewModel : INotifyPropertyChanged
    {
        #region Properties

        #endregion

        #region Delegates
        public Command BeginSetupCommand { get; }
        public Command SkipSetupCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor

        public SetupWelcomePageViewModel()
        {
            BeginSetupCommand = new Command(BeginSetupAction);
            SkipSetupCommand = new Command(SkipSetupAction);
        }

        private bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }
        #endregion

        #region Commands
        private void BeginSetupAction()
        {
            MobilePreference mobilePreference = new MobilePreference();
            SetupLanguagePageViewModel lang = new SetupLanguagePageViewModel(mobilePreference);
            SetupLanguagePage langPage = new SetupLanguagePage();
            langPage.BindingContext = lang;
            Application.Current.MainPage.Navigation.PushAsync(langPage);
        }

        private void SkipSetupAction()
        {
            //go to activity feed
            FeedTabbedPageViewModel feed = new FeedTabbedPageViewModel("news");
            FeedTabbedPage feedPage = new FeedTabbedPage();
            feedPage.BindingContext = feed;
            Application.Current.MainPage.Navigation.PushAsync(feedPage);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
