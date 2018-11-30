using Company.App.Presentation.ViewModels;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public class BusyOperationNotification : OperationNotificationBase
    {
        public BusyOperationNotification(int delay, int minDuration, bool isCancelable)
            : base(delay, minDuration, isCancelable)
        {
        }

        protected override void OnStartOperation(OperationContext context)
        {
            if (context.Owner is IViewModelWithOperation viewModel)
            {
                viewModel.IsBusy = true;
            }
        }

        protected override void OnFinishOperation(OperationContext context, OperationStatus status, object result)
        {
            if (context.Owner is IViewModelWithOperation viewModel && context.GetNotificationsCount<BusyOperationNotification>() == 0)
            {
                viewModel.IsBusy = false;
            }
        }
    }
}
