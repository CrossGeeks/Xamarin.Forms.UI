using System;
using System.Collections.Generic;
using UISampleApp.Views.SignUps;
using Xamarin.Forms;

namespace UISampleApp.Views.Logins
{
    public partial class LoginDaniaPage : ContentPage
    {
        public LoginDaniaPage()
        {
            InitializeComponent();
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new SignUpDaniaPage());
		}
    }
}
