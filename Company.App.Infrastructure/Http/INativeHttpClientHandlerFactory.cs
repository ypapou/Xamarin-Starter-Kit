using System.Net.Http;

namespace Company.App.Infrastructure.Http
{
    public interface INativeHttpClientHandlerFactory
    {
        HttpMessageHandler Create(bool enableDebugTracing = false);
    }
}
