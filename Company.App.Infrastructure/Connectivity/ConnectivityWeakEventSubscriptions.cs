using System;
using FlexiMvvm.Weak.Subscriptions;
using Xamarin.Essentials;

namespace Company.App.Infrastructure.Connectivity
{
    public static class ConnectivityWeakEventSubscriptions
    {
        public static IDisposable ConnectivityChangedWeakSubscribe(
            this IConnectivity connectivity,
            EventHandler<ConnectivityChangedEventArgs> connectivityChangedHandler)
        {
            return new WeakEventSubscription<IConnectivity, ConnectivityChangedEventArgs>(
                connectivity,
                (eventSource, eventHandler) => eventSource.ConnectivityChanged += eventHandler,
                (eventSource, eventHandler) => eventSource.ConnectivityChanged -= eventHandler,
                connectivityChangedHandler);
        }
    }
}
