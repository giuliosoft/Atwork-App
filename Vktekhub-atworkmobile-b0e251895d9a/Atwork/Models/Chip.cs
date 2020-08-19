using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Atwork.Models
{
    public class Chip
    {
        public bool CanSelect { get; set; }
        public string ChipText { get; set; }

        private Image imageSource;

        public Image GetImageSource()
        {
            return imageSource;
        }

        public void SetImageSource(Image value)
        {
            imageSource = value;
        }
    }
}
