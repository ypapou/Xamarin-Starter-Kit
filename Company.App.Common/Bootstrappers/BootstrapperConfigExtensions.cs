using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;

namespace Company.App.Common.Bootstrappers
{
    public static class BootstrapperConfigExtensions
    {
        private const string SimpleIocKey = "SimpleIoc";
        private const string AppExecutionEnvironmentKey = "AppExecutionEnvironment";

        public static ISimpleIoc GetSimpleIoc(this BootstrapperConfig config)
        {
            return config.GetValue<ISimpleIoc>(SimpleIocKey);
        }

        public static void SetSimpleIoc(this BootstrapperConfig config, ISimpleIoc simpleIoc)
        {
            config.SetValue(SimpleIocKey, simpleIoc);
        }

        public static AppExecutionEnvironment GetAppExecutionEnvironment(this BootstrapperConfig config)
        {
            return config.GetValue<AppExecutionEnvironment>(AppExecutionEnvironmentKey);
        }

        public static void SetAppExecutionEnvironment(this BootstrapperConfig config, AppExecutionEnvironment appExecutionEnvironment)
        {
            config.SetValue(AppExecutionEnvironmentKey, appExecutionEnvironment);
        }
    }
}
