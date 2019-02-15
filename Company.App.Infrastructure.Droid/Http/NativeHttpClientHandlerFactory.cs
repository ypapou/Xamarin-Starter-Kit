using System.Net.Http;
using FlexiMvvm.Net.Http;
using Xamarin.Android.Net;

namespace Company.App.Infrastructure.Http
{
    public class NativeHttpClientHandlerFactory : INativeHttpClientHandlerFactory
    {
        public HttpMessageHandler Create(bool enableDebugTracing = false)
        {
            var nativeClientHandler = Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop
                ? new AndroidClientHandler()
                : new HttpClientHandler();

            return enableDebugTracing
                ? new HttpTraceHandler(nativeClientHandler)
                : (HttpMessageHandler)nativeClientHandler;
        }
    }
}
