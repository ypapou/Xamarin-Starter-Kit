namespace Company.App.Application.Services.Connectivity
{
    public interface IConnectivityService
    {
        void ThrowIfNotConnected();
    }
}
