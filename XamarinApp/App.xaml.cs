using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;

namespace XamarinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            
            //AppActions.OnAppAction += AppActions_OnAppAction;
        }

        void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            // Don't handle events fired for old application instances
            // and cleanup the old instance's event handler
            //if (Application.Current != this && Application.Current is App app)
            //{
            //    AppActions.OnAppAction -= app.AppActions_OnAppAction;
            //    return;
            //}
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    var page = e.AppAction.Id switch
            //    {
            //        "battery_info" => new FeedbackPage(),
            //        "app_info" => new MainPage(),
            //        _ => default(Page)
            //    };
            //    if (page != null)
            //    {
            //        await Application.Current.MainPage.Navigation.PopToRootAsync();
            //        await Application.Current.MainPage.Navigation.PushAsync(page);
            //    }
            //});
        }

        protected async override void OnStart()
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("app_info", "App Info", icon: "app_info_action_icon"),
                    new AppAction("battery_info", "Battery Info"));
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
