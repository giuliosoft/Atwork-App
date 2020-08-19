using System;
using System.Collections.Generic;
using Atwork.ViewModels;
using Xamarin.Forms;

namespace Atwork
{
    public partial class DisclosurePage : ContentPage
    {
        public DisclosurePage()
        {
            InitializeComponent();
            BindingContext = new DisclosurePageViewModel();
        }
    }
}
