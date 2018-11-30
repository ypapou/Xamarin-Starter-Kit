using System.Threading.Tasks;
using Company.App.Infrastructure.Dialogs;

namespace Company.App.Application.UserInteraction
{
    public class UserInteractionService : IUserInteractionService
    {
        private readonly IUserDialog _userDialog;

        public UserInteractionService(IUserDialog userDialog)
        {
            _userDialog = userDialog;
        }

        public async Task ShowErrorAsync(string title, string message, string accept)
        {
            await _userDialog.AlertAsync(title, message, accept);
        }
    }
}
