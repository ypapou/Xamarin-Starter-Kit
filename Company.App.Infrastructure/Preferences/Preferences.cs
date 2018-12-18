using System;

namespace Company.App.Infrastructure.Preferences
{
    public sealed class Preferences : IPreferences
    {
        private static readonly Lazy<IPreferences> LazyInstance = new Lazy<IPreferences>(() => new Preferences());

        private Preferences()
        {
        }

        public static IPreferences Instance => LazyInstance.Value;

        public bool ContainsKey(string key)
        {
            return Xamarin.Essentials.Preferences.ContainsKey(key);
        }

        public bool ContainsKey(string key, string sharedName)
        {
            return Xamarin.Essentials.Preferences.ContainsKey(key, sharedName);
        }

        public string Get(string key, string defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public string Get(string key, string defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public bool Get(string key, bool defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public int Get(string key, int defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public int Get(string key, int defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public double Get(string key, double defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public double Get(string key, double defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public float Get(string key, float defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public float Get(string key, float defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public long Get(string key, long defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public long Get(string key, long defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public DateTime Get(string key, DateTime defaultValue)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue);
        }

        public DateTime Get(string key, DateTime defaultValue, string sharedName)
        {
            return Xamarin.Essentials.Preferences.Get(key, defaultValue, sharedName);
        }

        public void Set(string key, string value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, string value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, bool value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, bool value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, int value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, int value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, double value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, double value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, float value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, float value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, long value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, long value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Set(string key, DateTime value)
        {
            Xamarin.Essentials.Preferences.Set(key, value);
        }

        public void Set(string key, DateTime value, string sharedName)
        {
            Xamarin.Essentials.Preferences.Set(key, value, sharedName);
        }

        public void Remove(string key)
        {
            Xamarin.Essentials.Preferences.Remove(key);
        }

        public void Remove(string key, string sharedName)
        {
            Xamarin.Essentials.Preferences.Remove(key, sharedName);
        }

        public void Clear()
        {
            Xamarin.Essentials.Preferences.Clear();
        }

        public void Clear(string sharedName)
        {
            Xamarin.Essentials.Preferences.Clear(sharedName);
        }
    }
}
