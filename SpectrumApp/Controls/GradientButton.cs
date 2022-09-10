using System;
using Xamarin.Forms;

namespace SpectrumApp.Controls
{
    public class GradientButton : Button
    {
        public enum GradientOrientation
        {
            Vertical,
            Horizontal
        }

        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        public GradientOrientation GradientColorOrientation { get; set; }
    }
}

