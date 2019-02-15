﻿using Company.App.Ios.Theme;
using FlexiMvvm.Views;

namespace Company.App.Ios.Views.Template2
{
    public class Template2View : ScrollableLayoutView
    {
        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = AppTheme.Current.Colors.ContentBackground;
        }
    }
}
