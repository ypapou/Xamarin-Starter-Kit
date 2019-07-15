using System.ComponentModel;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public interface ISideBarNavigationMediator : INotifyPropertyChanged
    {
        SideBarMenuItem DefaultItem { get; set; }

        SideBarMenuItem SelectedItem { get; set; }

        Interaction CloseMenuInteraction { get; }
    }
}
