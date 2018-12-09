using System.Threading.Tasks;

namespace Company.App.Application.UserInteraction
{
    public interface IUserInteractionService
    {
        Task ShowErrorAsync(string title, string message, string accept);
    }
}
