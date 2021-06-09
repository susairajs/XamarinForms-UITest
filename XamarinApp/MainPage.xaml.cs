using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //xamarinWebview.Source = "https://xamarinmonkeys.blogspot.com/";
            //xamarinWebview.Navigated += async (o, s) => {
              //  await xamarinWebview.EvaluateJavaScriptAsync("document.getElementById('header-inner').style.visibility = 'hidden';");
            //};
        }

        void PhoneNumberValidate(System.Object sender, System.EventArgs e)
        {
            string phoneNumberRegax = "^[0-9]{10}$";

            if (!string.IsNullOrWhiteSpace(entryPhoneNumber.Text))
            {
                if (Regex.IsMatch(entryPhoneNumber.Text, phoneNumberRegax,
                     RegexOptions.IgnoreCase))
                {
                    lblResult.Text = "Valid";
                }
                else
                    lblResult.Text = "Not Valid";
            }
            else
                lblResult.Text = "Not Valid";

            
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            
            string url = string.Empty;
            var location = RegionInfo.CurrentRegion.Name.ToLower();
            if (Device.RuntimePlatform == Device.Android)
                url = "https://play.google.com/store/apps/details?id=com.sisystems.Sisystems";
            else if (Device.RuntimePlatform == Device.iOS)
                url = "https://itunes.apple.com/" + location + "/app/contractor-action-solution/id1039202852?mt=8";
            await Browser.OpenAsync(url, BrowserLaunchMode.External);
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://itunes.apple.com/in/app/facebook/id284882215?mt=8"));
        }

        void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IOpenAppStore>().OpenStore();
        }

        void Button_Clicked_3(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IOpenAppStore>().OpenAppStore();
        }

        
    }
}
