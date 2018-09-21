using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using GoodPlaces.Core.Controls;
using UIKit;
using CoreAnimation;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(GoodPlaces.iOS.CustomRenderers.CustomEntryRenderer))]
namespace GoodPlaces.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                //Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                var borderLayer = new CALayer();
                borderLayer.MasksToBounds = false;
                borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height - 10, UIScreen.MainScreen.Bounds.Size.Width - 100, 1f);
                borderLayer.BorderColor = UIColor.White.CGColor;
                borderLayer.BorderWidth = 1.0f;

                Control.Layer.AddSublayer(borderLayer);
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                //Control.Layer.SublayerTransform = CATransform3D.MakeTranslation(10, 0, 0);
            }
        }
    }
}
