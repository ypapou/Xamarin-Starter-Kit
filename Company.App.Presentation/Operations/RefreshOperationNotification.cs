using Company.App.Presentation.ViewModels;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public class RefreshOperationNotification : OperationNotification
    {
        public RefreshOperationNotification(int delay, int minDuration, bool isCancelable)
            : base(delay, minDuration, isCancelable)
        {
        }

        protected override void Show(OperationContext context)
        {
            if (context.Owner is IViewModelWithRefreshStatus viewModel)
            {
                viewModel.IsRefreshing = true;
            }
        }

        protected override void Hide(OperationContext context, OperationStatus status)
        {
            if (context.Owner is IViewModelWithRefreshStatus viewModel && context.Shared.GetNotificationCount<RefreshOperationNotification>() == 0)
            {
                viewModel.IsRefreshing = false;
            }
        }
    }
}
