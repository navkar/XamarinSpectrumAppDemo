using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SpectrumApp.ViewModels
{
    public class BaseViewModel : ObservableRecipient
    {
        public bool IsBusy {get;set;}

        public BaseViewModel()
        {
        }
    }
}

