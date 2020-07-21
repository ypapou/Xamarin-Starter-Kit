﻿using Company.App.Presentation.ViewModels;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views
{
    public class RootNavigationController : FlexiNavigationController<EntryViewModel>
    {
        public RootNavigationController()
        {
            NavigationBarHidden = true;
        }
    }
}
