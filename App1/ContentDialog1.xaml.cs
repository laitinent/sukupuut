using Sukupuut;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    public sealed partial class ContentDialog1 : ContentDialog
    {
        int? year;

        public int? Year { get => year;
            set {
                if (value != null)
                {
                    year = value;
                    DateTime dt = new DateTime((int)year, 6, 15);

                    calendar.Date = new DateTimeOffset(dt);
                }
            }
        }

        public ContentDialog1()
        {
            this.InitializeComponent();
            DateTime dt = new DateTime(1000,1,1);            
            calendar.MinYear = new DateTimeOffset(dt); 
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        

        public Henkilö GetDetails()
        {
            Henkilö h = new Henkilö(etunimiTextBox.Text, sukunimiTextBox.Text);
            h.Syntymäaika = calendar.Date.DateTime;
            return h;
        }
    }
}
