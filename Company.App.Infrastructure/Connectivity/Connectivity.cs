using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Company.App.Infrastructure.Connectivity
{
    public sealed class Connectivity : IConnectivity
    {
        private static readonly Lazy<IConnectivity> LazyInstance = new Lazy<IConnectivity>(() => new Connectivity());

        private Connectivity()
        {
        }

        public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged
        {
            add => Xamarin.Essentials.Connectivity.ConnectivityChanged += value;
            remove => Xamarin.Essentials.Connectivity.ConnectivityChanged -= value;
        }

        public static IConnectivity Instance => LazyInstance.Value;

        public NetworkAccess NetworkAccess => Xamarin.Essentials.Connectivity.NetworkAccess;

        public IEnumerable<ConnectionProfile> ConnectionProfiles => Xamarin.Essentials.Connectivity.ConnectionProfiles;
    }
}
