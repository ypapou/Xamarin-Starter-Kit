// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using CoreGraphics;
using UIKit;

namespace Company.App.Ios.Presenters
{
    public class OverlayPresentationController : UIPresentationController
    {
        private const float DimmedBackgroundTranslucentAlpha = 0.4f;

        public OverlayPresentationController(UIViewController presentedViewController, UIViewController presentingViewController)
            : base(presentedViewController, presentingViewController)
        {
        }

        public override CGRect FrameOfPresentedViewInContainerView =>
            new CGRect(ContainerView.Frame.X, ContainerView.Frame.Height - PresentedView.IntrinsicContentSize.Height, ContainerView.Frame.Width, PresentedView.IntrinsicContentSize.Height);

        private UIView DimmedBackgroundView { get; } = new UIView { BackgroundColor = UIColor.Black };

        public override void PresentationTransitionWillBegin()
        {
            base.PresentationTransitionWillBegin();

            ContainerView.AddSubview(DimmedBackgroundView);
            DimmedBackgroundView.Alpha = 0;

            var coordinator = PresentingViewController.GetTransitionCoordinator();
            coordinator.AnimateAlongsideTransition(_ => DimmedBackgroundView.Alpha = DimmedBackgroundTranslucentAlpha, null);
        }

        public override void DismissalTransitionWillBegin()
        {
            base.DismissalTransitionWillBegin();

            var coordinator = PresentingViewController.GetTransitionCoordinator();
            coordinator.AnimateAlongsideTransition(_ => DimmedBackgroundView.Alpha = 0, null);
        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);

            coordinator.AnimateAlongsideTransition(
                _ => PresentedView.Frame = new CGRect(ContainerView.Frame.X, toSize.Height - PresentedView.Frame.Height, toSize.Width, PresentedView.Frame.Height),
                null);
        }

        public override void ContainerViewDidLayoutSubviews()
        {
            base.ContainerViewDidLayoutSubviews();

            DimmedBackgroundView.Frame = ContainerView.Frame;
        }
    }
}
