using Company.App.Resources;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace Company.App.Application.Services.Connectivity
{
    public sealed class ConnectivityService : IConnectivityService
    {
        private readonly IConnectivity _connectivity;

        public ConnectivityService(IConnectivity connectivity)
        {
            _connectivity = connectivity;
        }

        public void ThrowIfNotConnected()
        {
            if (_connectivity.NetworkAccess == NetworkAccess.None)
            {
                throw new ConnectivityException(Strings.Exception_NoInternetConnection);
            }
        }
    }
}
