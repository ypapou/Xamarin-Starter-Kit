using System.Threading.Tasks;
using UIKit;

namespace Company.App.Infrastructure.Dialogs
{
    public class UserDialog : IUserDialog
    {
        public Task AlertAsync(string title, string message, string accept)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var alertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(accept, UIAlertActionStyle.Default, alertAction => taskCompletionSource.SetResult(true)));

            var topViewController = GetTopViewController();
            topViewController.PresentViewController(alertController, true, null);

            return taskCompletionSource.Task;
        }

        public Task<bool> ConfirmAsync(string title, string message, string accept, string cancel)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            var confirmController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            confirmController.AddAction(UIAlertAction.Create(accept, UIAlertActionStyle.Default, alertAction => taskCompletionSource.SetResult(true)));
            confirmController.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Default, alertAction => taskCompletionSource.SetResult(false)));

            var topViewController = GetTopViewController();
            topViewController.PresentViewController(confirmController, true, null);

            return taskCompletionSource.Task;
        }

        private UIViewController GetTopViewController()
        {
            return UIApplication.SharedApplication.KeyWindow.RootViewController;
        }
    }
}
