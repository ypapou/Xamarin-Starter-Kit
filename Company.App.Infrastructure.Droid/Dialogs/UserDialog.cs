using System;
using System.Threading.Tasks;
using Android.Support.V4.App;
using Plugin.CurrentActivity;

namespace Company.App.Infrastructure.Dialogs
{
    public class UserDialog : IUserDialog
    {
        private const string DialogFragmentTag = "UserDialog";

        public async Task AlertAsync(string title, string message, string accept)
        {
            var alertDialogFragment = AlertDialogFragment.NewInstance(title, message, accept);

            await ShowDialog(alertDialogFragment);
        }

        public async Task<bool> ConfirmAsync(string title, string message, string accept, string cancel)
        {
            var confirmDialogFragment = ConfirmDialogFragment.NewInstance(title, message, accept, cancel);

            return await ShowDialog(confirmDialogFragment);
        }

        private Task<bool> ShowDialog(IAsyncDialogFragment dialogFragment)
        {
            var currentActivity = CrossCurrentActivity.Current.Activity;

            if (currentActivity is FragmentActivity fragmentActivity)
            {
                return dialogFragment.ShowAsync(fragmentActivity.SupportFragmentManager, DialogFragmentTag);
            }
            else
            {
                throw new InvalidOperationException($"\"{nameof(UserDialog)}\" works only with \"{nameof(FragmentActivity)}\" activity instances.");
            }
        }
    }
}
