using System;
using CoreAnimation;
using CoreGraphics;
using SpectrumApp.Controls;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using SpectrumApp.iOS.CustomRenderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace SpectrumApp.iOS.CustomRenderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            if (this.Element != null && this.Element is GradientButton)
            { 
                var obj = this.Element as GradientButton;
                CGColor StartColor = obj.StartColor.ToCGColor();
                CGColor EndColor = obj.EndColor.ToCGColor();
                var gradientLayer = new CAGradientLayer();
                gradientLayer.Frame = rect;
                gradientLayer.Colors = new CGColor[] { StartColor, EndColor };

                if (obj.GradientColorOrientation == GradientButton.GradientOrientation.Horizontal)
                {
                    gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
                }
                NativeView.Layer.InsertSublayer(gradientLayer, 0);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}

