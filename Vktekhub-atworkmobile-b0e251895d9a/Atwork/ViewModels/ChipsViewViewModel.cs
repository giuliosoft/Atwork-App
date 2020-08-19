using Atwork.Models;
using Atwork.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Atwork.ViewModels
{
    public class ChipsViewViewModel
    {
        //collection to be shown as "tab cloud"
        public ObservableCollection<Chip> Chips;

        public ChipsViewViewModel()
        {

        }
    }
}
