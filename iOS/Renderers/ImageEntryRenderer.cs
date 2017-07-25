using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using UISampleApp.Controls;
using UISampleApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace UISampleApp.iOS.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            var element = (ImageEntry)this.Element;
            var textField = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
						textField.LeftViewMode = UITextFieldViewMode.Always;
						textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
						break;
					case ImageAlignment.Right:
						textField.RightViewMode = UITextFieldViewMode.Always;
						textField.RightView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
						break;
				}
			}

            textField.BorderStyle = UITextBorderStyle.None;
			CALayer bottomBorder = new CALayer
			{
                Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
				BorderWidth = 2.0f,
				BorderColor = element.LineColor.ToCGColor()
			};

			textField.Layer.AddSublayer(bottomBorder);
			textField.Layer.MasksToBounds = true;
        }

        private UIView GetImageView(string imagePath, int height, int width)
        {
			var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
			{
				Frame = new RectangleF(0, 0, width, height)
			};
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
			objLeftView.AddSubview(uiImageView);

			return objLeftView;
        }
    }
}
