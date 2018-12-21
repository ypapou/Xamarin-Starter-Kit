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
            // Arrange
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Internet);

            // Act
            var connectivityService = new ConnectivityService(connectivityMock);

            // Assert
            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsConstrainedInternet()
        {
            // Arrange
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.ConstrainedInternet);

            // Act
            var connectivityService = new ConnectivityService(connectivityMock);

            // Assert
            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsLocal()
        {
            // Arrange
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Local);

            // Act
            var connectivityService = new ConnectivityService(connectivityMock);

            // Assert
            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsTrue_WhenNetworkAccessIsUnknown()
        {
            // Arrange
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.Unknown);

            // Act
            var connectivityService = new ConnectivityService(connectivityMock);

            // Assert
            Assert.True(connectivityService.IsConnected);
        }

        [Fact]
        public void IsConnected_ReturnsFalse_WhenNetworkAccessIsNone()
        {
            // Arrange
            var connectivityMock = new ConnectivityMock();
            connectivityMock.SetNetworkAccess(NetworkAccess.None);

            // Act
            var connectivityService = new ConnectivityService(connectivityMock);

            // Assert
            Assert.False(connectivityService.IsConnected);
        }
    }
}
