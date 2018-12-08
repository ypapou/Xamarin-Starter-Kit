using System.Threading.Tasks;

namespace Company.App.Infrastructure.SecureStorage
{
    public class SecureStorage : ISecureStorage
    {
        private static volatile ISecureStorage _instance;
        private static readonly object Lock = new object();

        private SecureStorage()
        {
        }

        public static ISecureStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SecureStorage();
                        }
                    }
                }

                return _instance;
            }
        }

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
