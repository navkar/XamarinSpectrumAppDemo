using System;
using Xamarin.Forms;

namespace SpectrumApp.Controls
{
    public class LocalGradientContentPage : ContentPage
    {
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            nameof(EndColor),
            typeof(Color),
            typeof(LocalGradientContentPage),
            Color.White);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            nameof(StartColor),
            typeof(Color),
            typeof(LocalGradientContentPage),
            Color.Black);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
    }
}

