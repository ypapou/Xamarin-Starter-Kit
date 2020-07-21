using Android.OS;
using Android.Views;
using Company.App.Presentation.ViewModels.Template3;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.Template3
{
    public class Template3Fragment : FlexiBindableFragment<Template3ViewModel>
    {
        public static Template3Fragment NewInstance()
        {
            return new Template3Fragment();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.template3, container, false);
        }

        public override void OnStart()
        {
            base.OnStart();

            Activity.SetTitle(Resource.String.Template3_Title);
        }
    }
}
