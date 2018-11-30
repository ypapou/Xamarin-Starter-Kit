using Company.App.Application.Bootstrappers;
using Company.App.Common.Bootstrappers;
using Company.App.iOS.Bootstrappers;
using Company.App.iOS.Views;
using Company.App.Infrastructure.Bootstrappers;
using Company.App.Presentation.Bootstrappers;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using UIKit;

namespace Company.App.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
#if QA_ENV
            AppCenter.Start(typeof(Crashes));
#else
            AppCenter.Start(typeof(Crashes));
#endif

            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());
            var compositeBootstrapper = new CompositeBootstrapper(
                new CommonBootstrapper(),
                new InfrastructureBootstrapper(),
                new iOSInfrastructureBootstrapper(),
                new ApplicationBootstrapper(),
                new PresentationBootstrapper(),
                new iOSBootstrapper());
            compositeBootstrapper.Execute(config);

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new RootNavigationController()
            };
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}


