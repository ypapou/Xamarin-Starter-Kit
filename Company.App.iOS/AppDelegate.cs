using Company.App.Ios.Bootstrappers;
using Company.App.Ios.Views;
using Foundation;
using UIKit;

namespace Company.App.Ios
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            InitialBootstrapper.Execute();

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new RootNavigationController()
            };
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
