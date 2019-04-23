using Android.Content;
using Android.OS;
using FlexiMvvm.Navigation;

namespace Company.App.Droid.Navigation
{
    public static class ForwardNavigationStrategyExtensions
    {
        public static ForwardNavigationDelegate StartActivity(
            this ForwardNavigationStrategy navigationStrategy,
            bool clearBackStack,
            bool singleTop,
            Bundle options = null)
        {
            return (sourceView, targetViewIntent, requestCode) =>
            {
                if (clearBackStack)
                {
                    targetViewIntent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
                }

                if (singleTop)
                {
                    targetViewIntent.AddFlags(ActivityFlags.SingleTop);
                }

                sourceView.StartActivity(targetViewIntent, options);
            };
        }
    }
}
