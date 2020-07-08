using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public static class OperationBuilderExtensions
    {
        public static IOperationBuilder WithBusyNotification(
            this IOperationBuilder builder,
            int delay = 100,
            int minDuration = 1000,
            bool isCancellable = false)
        {
            return builder.WithNotification(new BusyOperationNotification(delay, minDuration, isCancellable));
        }

        public static IOperationBuilder WithRefreshNotification(
            this IOperationBuilder builder,
            int delay = 0,
            int minDuration = 0,
            bool isCancellable = false)
        {
            return builder.WithNotification(new RefreshOperationNotification(delay, minDuration, isCancellable));
        }
    }
}
