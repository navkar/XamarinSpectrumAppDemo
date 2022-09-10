using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpectrumApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            App.Current.PageDisappearing += Current_PageDisappearing;
        }

        private void Current_PageDisappearing(object sender, Page e)
        {
            throw new NotImplementedException();
        }
    }
}

