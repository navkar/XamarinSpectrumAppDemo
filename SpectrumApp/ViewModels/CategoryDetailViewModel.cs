using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Input;
using SpectrumApp.Data;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace SpectrumApp.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        public string WebUrl { get; set; }
        public string Name { get; set; }

        public ICommand OpenBrowserCommand { get; set; }

        public CategoryDetailViewModel()
        {
            MessagingCenter.Subscribe<CategoryModel>(this, "SelectedCategory", LoadCategory);
            OpenBrowserCommand = new RelayCommand<string>(async (url) => await WebBrowser(url));
        }

        private void LoadCategory(CategoryModel model)
        {
            Name = model.Name;
            WebUrl = model.Url;
        }

        private async Task WebBrowser(string uri)
        {
            await Browser.OpenAsync(uri, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }

    }
}

