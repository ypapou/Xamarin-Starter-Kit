using System.Threading.Tasks;
using Company.App.Infrastructure.Views;

namespace Company.App.Infrastructure.Dialogs
{
    public class UserDialog : IUserDialog
    {
        private const string DialogFragmentTag = "UserDialog";

        public async Task AlertAsync(string title, string message, string accept)
        {
            var fragmentManager = ViewProvider.GetCurrentActivity().SupportFragmentManager;
            var alertDialogFragment = AlertDialogFragment.NewInstance(title, message, accept);

            await alertDialogFragment.ShowAsync(fragmentManager, DialogFragmentTag);
        }

        public async Task<bool> ConfirmAsync(string title, string message, string accept, string cancel)
        {
            var fragmentManager = ViewProvider.GetCurrentActivity().SupportFragmentManager;
            var confirmDialogFragment = ConfirmDialogFragment.NewInstance(title, message, accept, cancel);

            return await confirmDialogFragment.ShowAsync(fragmentManager, DialogFragmentTag);
        }
    }
}
