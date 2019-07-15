using FlexiMvvm;
using FlexiMvvm.ViewModels;

namespace Company.App.Presentation.ViewModels.SideBar
{
    public class SideBarNavigationMediator : ObservableObject, ISideBarNavigationMediator
    {
        public SideBarMenuItem DefaultItem { get; set; }

        public SideBarMenuItem SelectedItem { get; set; }

        public Interaction CloseMenuInteraction { get; } = new Interaction();
    }
}
