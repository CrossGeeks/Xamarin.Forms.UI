using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using UISampleApp.Droid.Effects;
using UISampleApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(DroidBackgroundEntryEffect), "BackgroundEffect")]
namespace UISampleApp.Droid.Effects
{
	public class DroidBackgroundEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				var nativeEditText = (global::Android.Widget.EditText)Control;
				var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
				shape.Paint.SetStyle(Paint.Style.Stroke);
				nativeEditText.Background = shape;
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
