using UIKit;

namespace Company.App.Infrastructure.Views
{
    public static class ViewProvider
    {
        public static UIViewController GetCurrentViewController()
        {
            return UIApplication.SharedApplication.KeyWindow.RootViewController;
        }
    }
}
