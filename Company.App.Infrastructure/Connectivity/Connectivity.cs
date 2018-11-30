using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Company.App.Infrastructure.Connectivity
{
    public class Connectivity : IConnectivity
    {
        private static volatile Connectivity _instance;
        private static readonly object Lock = new object();

        private Connectivity()
        {
        }

        public event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged
        {
            add => Xamarin.Essentials.Connectivity.ConnectivityChanged += value;
            remove => Xamarin.Essentials.Connectivity.ConnectivityChanged -= value;
        }

        public static IConnectivity Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Connectivity();
                        }
                    }
                }

                return _instance;
            }
        }

        public NetworkAccess NetworkAccess => Xamarin.Essentials.Connectivity.NetworkAccess;

        public IEnumerable<ConnectionProfile> ConnectionProfiles => Xamarin.Essentials.Connectivity.ConnectionProfiles;
    }
}
