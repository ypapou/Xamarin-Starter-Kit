using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace Company.App.Application.Tests.Connectivity
{
    public class ConnectivityMock : IConnectivity
    {
        public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;

        public NetworkAccess NetworkAccess { get; private set; }

        public IEnumerable<ConnectionProfile> ConnectionProfiles { get; private set; }

        public void SetConnectionProfiles(IEnumerable<ConnectionProfile> connectionProfiles)
        {
            ConnectionProfiles = connectionProfiles;
        }

        public void SetNetworkAccess(NetworkAccess networkAccess)
        {
            NetworkAccess = networkAccess;

            ConnectivityChanged?.Invoke(this, new ConnectivityChangedEventArgs(NetworkAccess, ConnectionProfiles));
        }
    }
}
