using System;
using System.Collections.Generic;
using SpectrumApp.ViewModels;
using Xamarin.Forms;

namespace SpectrumApp.Views
{
    public partial class CategoryDetailView : ContentPage
    {
        public CategoryDetailView()
        {
            InitializeComponent();
        }

        public CategoryDetailViewModel ViewModel => BindingContext as CategoryDetailViewModel;

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

