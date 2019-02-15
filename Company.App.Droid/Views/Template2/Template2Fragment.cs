using Android.OS;
using Android.Views;
using Company.App.Presentation.ViewModels.Template2;
using FlexiMvvm.Views;

namespace Company.App.Droid.Views.Template2
{
    public class Template2Fragment : Fragment<Template2ViewModel>
    {
        public static Template2Fragment NewInstance()
        {
            return new Template2Fragment();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.template2, container, false);
        }

        public override void OnStart()
        {
            base.OnStart();

            Activity.SetTitle(Resource.String.Template2_Title);
        }
    }
}
