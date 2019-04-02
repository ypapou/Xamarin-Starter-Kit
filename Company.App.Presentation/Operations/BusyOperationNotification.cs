using Company.App.Presentation.ViewModels;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public class BusyOperationNotification : OperationNotification
    {
        public BusyOperationNotification(int delay, int minDuration, bool isCancelable)
            : base(delay, minDuration, isCancelable)
        {
        }

        protected override void Show(OperationContext context)
        {
            if (context.Owner is IViewModelWithOperation viewModel)
            {
                viewModel.IsBusy = true;
            }
        }

        protected override void Hide(OperationContext context, OperationStatus status)
        {
            if (context.Owner is IViewModelWithOperation viewModel && context.Shared.GetNotificationCount<BusyOperationNotification>() == 0)
            {
                viewModel.IsBusy = false;
            }
        }
    }
}
