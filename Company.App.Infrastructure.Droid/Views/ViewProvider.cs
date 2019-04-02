using System;
using Android.Support.V4.App;
using Plugin.CurrentActivity;

namespace Company.App.Infrastructure.Views
{
    public static class ViewProvider
    {
        public static FragmentActivity GetCurrentActivity()
        {
            if (CrossCurrentActivity.Current.Activity is FragmentActivity fragmentActivity)
            {
                return fragmentActivity;
            }

            throw new InvalidOperationException($"'{nameof(ViewProvider)}' works only with activities derived from the '{nameof(FragmentActivity)}'.");
        }
    }
}
