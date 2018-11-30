using Android.App;
using Android.OS;
using Company.App.Android.Bootstrappers;
using Company.App.Application.Bootstrappers;
using Company.App.Common.Bootstrappers;
using Company.App.Infrastructure.Bootstrappers;
using Company.App.Presentation.Bootstrappers;
using Company.App.Presentation.ViewModels;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.Views.V7;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Plugin.CurrentActivity;

namespace Company.App.Android.Views
{
    [Activity(MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : FlxAppCompatActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
#if QA_ENV
            AppCenter.Start(typeof(Crashes));
#else
            AppCenter.Start(typeof(Crashes));
#endif

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());
            var compositeBootstrapper = new CompositeBootstrapper(
                new CommonBootstrapper(),
                new InfrastructureBootstrapper(),
                new AndroidInfrastructureBootstrapper(),
                new ApplicationBootstrapper(),
                new PresentationBootstrapper(),
                new AndroidBootstrapper());
            compositeBootstrapper.Execute(config);

            base.OnCreate(savedInstanceState);
        }
    }
}