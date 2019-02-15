using System.Net.Http;
using FlexiMvvm.Net.Http;

namespace Company.App.Infrastructure.Http
{
    public class NativeHttpClientHandlerFactory : INativeHttpClientHandlerFactory
    {
        public HttpMessageHandler Create(bool enableDebugTracing = false)
        {
            var nativeClientHandler = new NSUrlSessionHandler();

            return enableDebugTracing
                ? new HttpTraceHandler(nativeClientHandler)
                : (HttpMessageHandler)nativeClientHandler;
        }
    }
}
