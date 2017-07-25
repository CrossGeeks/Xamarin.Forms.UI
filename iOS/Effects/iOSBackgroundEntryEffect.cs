using System;
using UIKit;
using UISampleApp.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(iOSBackgroundEntryEffect), "BackgroundEffect")]
namespace UISampleApp.iOS.Effects
{
	public class iOSBackgroundEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				var view = this.Control as UITextField;
				if (view == null)
					return;

                view.BorderStyle = UITextBorderStyle.Line;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{

		}
	}
}
