using System;
using Android.Content;
using Android.Graphics;
using Android.Hardware.Lights;
using SpectrumApp.Controls;
using SpectrumApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace SpectrumApp.Droid.CustomRenderers
{
    public class GradientButtonRenderer : ButtonRenderer
    {
        public GradientButtonRenderer(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {

            LinearGradient gradient = null;

            // For Horizontal Gradient
            if (((GradientButton)Element).GradientColorOrientation == GradientButton.GradientOrientation.Horizontal)
            {
                gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,



                     ((GradientButton)Element).StartColor.ToAndroid(),
                     ((GradientButton)Element).EndColor.ToAndroid(),

                     Android.Graphics.Shader.TileMode.Mirror);

            }
            //For Veritical Gradient
            if (((GradientButton)Element).GradientColorOrientation == GradientButton.GradientOrientation.Vertical)
            {
                gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,



                     ((GradientButton)Element).StartColor.ToAndroid(),
                     ((GradientButton)Element).EndColor.ToAndroid(),

                     Android.Graphics.Shader.TileMode.Mirror);

            }

            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

    }

}

