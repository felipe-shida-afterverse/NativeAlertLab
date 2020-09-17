using System.Runtime.InteropServices;

namespace Plugins.iOS
{
    public static class IOSBundleVersionCode
    {
        private static string _cache;

        public static string BundleCode
        {
            get
            {
                if (string.IsNullOrEmpty(_cache))
                {
                    _cache = GetBuildNumber();
                }

                return _cache;
            }
        }
        
        [DllImport("__Internal")]
        private static extern string GetBuildNumber();
    }
}