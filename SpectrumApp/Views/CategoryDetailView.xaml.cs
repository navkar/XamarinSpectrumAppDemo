using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.DependencyInjection;
using SpectrumApp.ViewModels;
using Xamarin.Forms;

namespace SpectrumApp.Views
{
    public partial class CategoryDetailView : ContentPage
    {
        public CategoryDetailView()
        {
            InitializeComponent();
            this.BindingContext = Ioc.Default.GetRequiredService<CategoryDetailViewModel>();
        }

        public CategoryDetailViewModel ViewModel => BindingContext as CategoryDetailViewModel;

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

