using System.Threading.Tasks;
using Android.Support.V4.App;

namespace Company.App.Infrastructure.Dialogs
{
    internal interface IAsyncDialogFragment
    {
        Task<bool> ShowAsync(FragmentManager manager, string tag);
    }
}
