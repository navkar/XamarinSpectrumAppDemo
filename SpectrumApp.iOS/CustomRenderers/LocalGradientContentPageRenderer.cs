using System;
using CoreAnimation;
using CoreGraphics;
using SpectrumApp.Controls;
using SpectrumApp.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LocalGradientContentPage), typeof(LocalGradientContentPageRenderer))]
namespace SpectrumApp.iOS.CustomRenderers
{
    public class LocalGradientContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null) return;
            if (e.NewElement is LocalGradientContentPage page)
            {
                var gradientLayer = new CAGradientLayer
                {
                    Frame = View.Bounds,
                    Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() }
                };
                View.Layer.InsertSublayer(gradientLayer, 0);
            }
        }
    }
}

