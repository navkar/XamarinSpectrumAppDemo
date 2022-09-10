using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using SpectrumApp.Data;
using SpectrumApp.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;

namespace SpectrumApp.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel, IQueryAttributable
    {
        private CategoryModel currentCategory;
        public CategoryModel CurrentCategory
        {
            get => currentCategory;
            set => SetProperty(ref currentCategory, value, null);
        }

        public ICommand OpenBrowserCommand { get; set; }

        public CategoryDetailViewModel()
        {
            OpenBrowserCommand = new RelayCommand(async () => await WebBrowser());
        }

        private async Task WebBrowser()
        {
            await Browser.OpenAsync(CurrentCategory.Url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            var categoryName = HttpUtility.UrlDecode(query[Constants.CATEGORY_NAME]);
            Init(categoryName);
        }

        private void Init(string categoryName)
        {
            var jsonData = FileManager.ReadEmbeddedFile(Constants.CATEGORY_EMBEDDED_RESOURCE_ID);
            var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonData);
            CurrentCategory = categories.Where(x => x.Name == categoryName).FirstOrDefault();
            OnPropertyChanged(nameof(CurrentCategory));
        }
    }
}

