using Serilog;

using System;
using System.Reflection;

namespace Glasssix.MicaUI.SampleApp
{
    public partial class App
    {
        public static bool IsMultiThreaded { get; } = false;

        public App()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("log").CreateLogger();
            Startup += App_Startup;
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            Log.Information("Start");
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Log.Error(e.Exception, "");
        }

        public static TEnum GetEnum<TEnum>(string text) where TEnum : struct
        {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
            {
                throw new InvalidOperationException("Generic parameter 'TEnum' must be an enum.");
            }
            return (TEnum)Enum.Parse(typeof(TEnum), text);
        }
    }
}