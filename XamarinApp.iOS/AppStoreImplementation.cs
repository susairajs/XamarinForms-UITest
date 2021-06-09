using System;
using Foundation;
using StoreKit;
using UIKit;
using Xamarin.Forms;
using XamarinApp.iOS;

[assembly:Dependency(typeof(AppStoreImplementation))]
namespace XamarinApp.iOS
{
    public class AppStoreImplementation : UIViewController, ISKStoreProductViewControllerDelegate, IOpenAppStore
    {
        public void OpenAppStore()
        {
            var storeViewController = new SKStoreProductViewController();
            storeViewController.Delegate = this;
            var id = SKStoreProductParameterKey.ITunesItemIdentifier;
            var productDictonryKey = new NSDictionary("SKStoreProductParameterITunesItemIdentifier", "284882215");
            var parameters = new StoreProductParameters(productDictonryKey);
            storeViewController.LoadProduct(parameters,(bool loaded,NSError err)=>
            {
                if(loaded)
                {
                    this.PresentViewController(storeViewController, true, () =>
                    {

                    });
                }
            });
        }

        public void OpenStore()
        {
            Device.OpenUri(new Uri("https://itunes.apple.com/in/app/facebook/id284882215?mt=8"));
        }
    }
}
