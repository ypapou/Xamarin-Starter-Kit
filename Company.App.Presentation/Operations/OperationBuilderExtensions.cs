using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public static class OperationBuilderExtensions
    {
        public static IOperationBuilder WhenConnectedToInternet(this IOperationBuilder builder)
        {
            return builder.WithCondition(new InternetConnectionOperationCondition());
        }

        public static IOperationBuilder WithBusyNotification(
            this IOperationBuilder builder,
            int delay = 100,
            int minDuration = 1000,
            bool isCancellable = false)
        {
            return builder.WithNotification(new BusyOperationNotification(delay, minDuration, isCancellable));
        }
    }
}
