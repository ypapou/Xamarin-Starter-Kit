using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Company.App.Infrastructure.Connectivity
{
    public interface IConnectivity
    {
        event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

        NetworkAccess NetworkAccess { get; }

        IEnumerable<ConnectionProfile> ConnectionProfiles { get; }
    }
}
