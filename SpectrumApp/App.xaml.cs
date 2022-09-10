using System;
using SpectrumApp.ViewModels;
using SpectrumApp.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpectrumApp
{
    public partial class App : Application
    {
        private bool _initialized;

        public App ()
        {
            InitializeComponent();

            if(!_initialized)
            {
                _initialized = true;
                Ioc.Default.ConfigureServices(
                    new ServiceCollection()
                    //Services
                    
                    //ViewModels
                    .AddTransient<CategoryViewModel>()
                    .AddTransient<CategoryDetailViewModel>()
                    .BuildServiceProvider());
            }

            MainPage = new AppShell();
            App.Current.PageAppearing += Current_PageAppearing;
        }

        private void Current_PageAppearing(object sender, Page e)
        {
            
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);
        }

        

    }
}

