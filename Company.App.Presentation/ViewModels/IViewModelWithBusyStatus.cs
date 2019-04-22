using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels
{
    public interface IViewModelWithBusyStatus : IViewModel
    {
        bool IsBusy { get; set; }
    }
}
