using System;
using System.Collections.Generic;
using SpectrumApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("categoryDetailView", typeof(CategoryDetailView));

            BindingContext = this;
        }
    }
}

