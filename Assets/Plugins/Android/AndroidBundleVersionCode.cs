using UnityEngine;

namespace Plugins.Android
{
    public static class AndroidBundleVersionCode
    {
        private static string _cache;

        public static string BundleCode
        {
            get
            {
                if (string.IsNullOrEmpty(_cache))
                {
                    _cache = FetchBundleVersionCode();
                }

                return _cache;
            }
        }

        private static string FetchBundleVersionCode()
        {
            AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            var ca = up.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");

            var pInfo = packageManager.Call<AndroidJavaObject>("getPackageInfo", Application.identifier, 0);

            return pInfo.Get<int>("versionCode").ToString();
        }
    }
}