using System;
using System.Threading.Tasks;

namespace Company.App.Infrastructure.SecureStorage
{
    public sealed class SecureStorage : ISecureStorage
    {
        private static readonly Lazy<ISecureStorage> LazyInstance = new Lazy<ISecureStorage>(() => new SecureStorage());

        private SecureStorage()
        {
        }

        public static ISecureStorage Instance => LazyInstance.Value;

        public async Task<string> GetAsync(string key)
        {
            return await Xamarin.Essentials.SecureStorage.GetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            return Xamarin.Essentials.SecureStorage.Remove(key);
        }

        public void RemoveAll()
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }
    }
}
