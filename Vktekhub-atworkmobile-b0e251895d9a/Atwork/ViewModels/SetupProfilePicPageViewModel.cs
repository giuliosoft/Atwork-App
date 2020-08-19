using Atwork.Commands;
using Atwork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Atwork.ViewModels
{
    public class SetupProfilePicPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Image> AvatarList { get; }
        public MobilePreference m;
        #endregion

        #region Delegates
        public Command ChooseFromRollCommand { get; }
        public Command ChooseFromOursCommand { get; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Contructor

        public SetupProfilePicPageViewModel()
        {
            
            ChooseFromRollCommand = new Command(ChooseFromRollAction);
            ChooseFromOursCommand = new Command(ChooseFromOursAction);
        }

        public bool CanExecuteCommand(object commandParameter)
        {
            return true;
        }

        #endregion

        #region Commands
        private void ChooseFromRollAction()
        { 
            SetupPickCameraRollPageViewModel camera = new SetupPickCameraRollPageViewModel();
            SetupPickCameraRollPage cameraPage = new SetupPickCameraRollPage();
            cameraPage.BindingContext = camera;
            Application.Current.MainPage.Navigation.PushAsync(cameraPage);
        }

        private void ChooseFromOursAction()
        {
            //open the  navigation drawer
            //navDrawer.ToggleDrawer();

            //SetupPickOurPicPageViewModel ours = new SetupPickOurPicPageViewModel();
            //SetupPickOurPicPage oursPage = new SetupPickOurPicPage();
            //oursPage.BindingContext = ours;
            //Application.Current.MainPage.Navigation.PushAsync(oursPage);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
