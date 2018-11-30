using System.Threading.Tasks;

namespace Company.App.Infrastructure.Dialogs
{
    public interface IUserDialog
    {
        Task AlertAsync(string title, string message, string accept);

        Task<bool> ConfirmAsync(string title, string message, string accept, string cancel);
    }
}
