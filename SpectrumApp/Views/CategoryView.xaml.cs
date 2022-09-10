using System;
using System.Collections.Generic;
using SpectrumApp.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SpectrumApp.Controls;

namespace SpectrumApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        public CategoryView()
        {
            InitializeComponent();
            this.BindingContext = Ioc.Default.GetRequiredService<CategoryViewModel>();
        }

        public CategoryViewModel ViewModel => BindingContext as CategoryViewModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel == null) return;
            ViewModel.Reload();
        }

        void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
        }
    }
}

