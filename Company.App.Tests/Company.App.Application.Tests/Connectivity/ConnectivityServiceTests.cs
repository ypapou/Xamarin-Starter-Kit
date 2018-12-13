using Company.App.Application.Connectivity;
using Xamarin.Essentials;
using Xunit;

namespace Company.App.Application.Tests.Connectivity
{
    public class ConnectivityServiceTests
    {
        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsInternet()
        {
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Internet);

            var connectivityService = new ConnectivityService(connectivityMock);

            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsConstrainedInternet()
        {
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.ConstrainedInternet);

            var connectivityService = new ConnectivityService(connectivityMock);

            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsLocal()
        {
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Local);

            var connectivityService = new ConnectivityService(connectivityMock);

            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsUnknown()
        {
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Unknown);

            var connectivityService = new ConnectivityService(connectivityMock);

            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsFalse_WhenNetworkAccessIsNone()
        {
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.None);

            var connectivityService = new ConnectivityService(connectivityMock);

            Assert.False(connectivityService.IsConnected);
        }
    }
}
