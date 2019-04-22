using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels
{
    public interface IViewModelWithRefreshStatus : IViewModel
    {
        bool IsRefreshing { get; set; }
    }
}
