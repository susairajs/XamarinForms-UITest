using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinApp.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.Debug().ApkFile("../../../XamarinApp.Android/bin/Debug/com.companyname.xamarinapp.apk").StartApp();
            }

            return ConfigureApp.iOS.AppBundle("../../../XamarinApp.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone 8 plus-13.3/XamarinApp.iOS.app").StartApp();
        }
    }
}