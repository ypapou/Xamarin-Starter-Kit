using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Common.Bootstrappers
{
    public static class BootstrapperConfigExtensions
    {
        private const string SimpleIocKey = "SimpleIoc";

        public static ISimpleIoc GetSimpleIoc(this BootstrapperConfig config)
        {
            return (ISimpleIoc)config.Get(SimpleIocKey);
        }

        public static void SetSimpleIoc(this BootstrapperConfig config, ISimpleIoc simpleIoc)
        {
            config.Set(SimpleIocKey, simpleIoc);
        }
    }
}
