using System.Threading.Tasks;

namespace Company.App.Infrastructure.Dialogs
{
    internal interface IAsyncDialogFragment
    {
        Task<bool> ShowAsync(Android.Support.V4.App.FragmentManager manager, string tag);
    }
}
