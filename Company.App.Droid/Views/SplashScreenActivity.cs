using Android.App;
using Android.OS;
using Company.App.Droid.Bootstrappers;
using Company.App.Presentation.ViewModels;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/AppTheme.SplashScreen")]
    public class SplashScreenActivity : AppCompatActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            InitialBootstrapper.Execute(this, savedInstanceState);

            base.OnCreate(savedInstanceState);
        }
    }
}
