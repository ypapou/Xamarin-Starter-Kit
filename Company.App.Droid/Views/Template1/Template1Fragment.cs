using Android.OS;
using Android.Views;
using Company.App.Presentation.ViewModels.Template1;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.Template1
{
    public class Template1Fragment : FlexiBindableFragment<Template1ViewModel>
    {
        public static Template1Fragment NewInstance()
        {
            return new Template1Fragment();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.template1, container, false);
        }

        public override void OnStart()
        {
            base.OnStart();

            Activity.SetTitle(Resource.String.Template1_Title);
        }
    }
}
