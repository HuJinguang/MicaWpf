using System;

namespace Glasssix.MicaUI
{
    internal static class PackUriHelper
    {
        public static Uri GetAbsoluteUri(string path)
        {
            return new Uri($"pack://application:,,,/Glasssix.MicaUI;component/{path}");
        }
    }
}
