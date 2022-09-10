using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SpectrumApp.Data;
using SpectrumApp.Utils;
using SpectrumApp.Views;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Xamarin.Forms;
using MvvmHelpers;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SpectrumApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableRangeCollection<CategoryModel> categoryList;
        public ObservableRangeCollection<CategoryModel> CategoryList
        {
            get => categoryList;
            set => SetProperty(ref categoryList, value, null);
        }

        public CategoryModel SelectedCategory { get; set; }
        public ICommand CategoryCommand { get; set; }
        public ICommand SortingCommand { get; set; }
        public ICommand VerifyCommand { get; set; }
        public Command FilterCommand => new Command(async () => { await DelayedQueryForKeyboardTypingSearches(500).ConfigureAwait(false); });
        public string FilterQuery { get; set; }
        public double AgeOfUniverse { get; set; }
        public bool SortOrderAsc { get; set; } = true;

        public DateTime TodaysDate => DateTime.UtcNow;

        public CategoryViewModel()
        {
            CategoryCommand = new RelayCommand(DisplayDialog);
            VerifyCommand = new RelayCommand(VerifyAgeOfUniverse);
            SortingCommand = new RelayCommand(SortingCategories);
        }

        private void SortingCategories()
        {
            if (SortOrderAsc)
                CategoryList.ReplaceRange(CategoryList.OrderBy(x => x.Name).ToList());
            else
                CategoryList.ReplaceRange(CategoryList.OrderByDescending(x => x.Name).ToList());

            SortOrderAsc = !SortOrderAsc;
            OnPropertyChanged(nameof(CategoryList));
        }

        //protected override void OnActivated()
        //{
        //    Messenger.Register<MyViewModel, LoggedInUserRequestMessage>(this, (r, m) =>
        //    {
        //        // Handle the message here
        //    });
        //}

        public void Reload()
        {
            if (CategoryList == null)
                CategoryList = new ObservableRangeCollection<CategoryModel>();

            var jsonData = FileManager.ReadEmbeddedFile(Constants.CATEGORY_EMBEDDED_RESOURCE_ID);
            var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonData);
            CategoryList.ReplaceRange(categories);
            OnPropertyChanged(nameof(CategoryList));
        }

        private async void DisplayDialog()
        {
            ////await App.Current.MainPage.DisplayAlert("Selected", SelectedCategory.Name, "OK");

            //MessagingCenter.Instance.Send(typeof(CategoryModel), "SelectedCategory", SelectedCategory);
            //await NavigationPage.PushAsync(new CategoryDetailView());

            //Shell.Current.GoToAsync();
        }

        private async void VerifyAgeOfUniverse()
        {
            if (AgeOfUniverse <= 0 || AgeOfUniverse < 13.6 || AgeOfUniverse > 13.7)
            {
                await App.Current.MainPage.DisplayAlert("Answer","The correct answer is 13.7 billion years!", "OK");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Perfect!", "That's correct.", "OK");
        }

        private CancellationTokenSource cts = new CancellationTokenSource();

        private async Task DelayedQueryForKeyboardTypingSearches(int millis)
        {
            try
            {
                Interlocked.Exchange(ref this.cts, new CancellationTokenSource()).Cancel();

                await Task.Delay(TimeSpan.FromMilliseconds(millis), this.cts.Token)
                          .ContinueWith(async task => await Query(FilterQuery),
                                        CancellationToken.None,
                                        TaskContinuationOptions.OnlyOnRanToCompletion,
                                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
                //Ignore any Threading errors
            }
        }

        public async Task Query(string searchPhrase)
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                if (string.IsNullOrEmpty(searchPhrase)) Reload();
                else
                {
                    var items = CategoryList.Where(x => x.Name.ToLower().Contains(searchPhrase.ToLower())).ToList();
                    CategoryList.ReplaceRange(items);
                    await Task.Delay(0);
                }
            }
            finally
            {
                IsBusy = false;
                OnPropertyChanged(nameof(CategoryList));
            }
        }
    }
}

