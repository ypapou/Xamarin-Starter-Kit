using Android.Content;
using FlexiMvvm.Navigation;

namespace Company.App.Droid.Navigation
{
    public static class ForwardNavigationStrategyExtensions
    {
        public static ForwardNavigationDelegate ClearBackStack(this ForwardNavigationStrategy navigationStrategy)
        {
            return (sourceView, targetViewIntent, requestCode) =>
            {
                targetViewIntent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            };
        }
    }
}
