using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Android
{
    public class AndroidToastSender
    {
        private const string UNITY_PLAYER_CLASS_PACKAGE = "com.unity3d.player.UnityPlayer";

        AndroidJavaObject currentActivity;
        private string toastString;
        private string toastLength;

        public AndroidToastSender(string toastString, string toastLength)
        {
            this.toastString = toastString;
            this.toastLength = toastLength;
        }

        public IEnumerator RunToastOnUIThreadAndroid()
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass(UNITY_PLAYER_CLASS_PACKAGE);

            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(ShowToast));

            yield return null;
        }

        private void ShowToast()
        {
            Debug.Log("Running on UI thread");
            object[] toastParams = new object[3];

            toastParams[0] = currentActivity;
            toastParams[1] = toastString;

            AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");

            toastParams[2] = Toast.GetStatic<int>(toastLength);

            AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", toastParams);

            toast.Call("show");
        }
    }
}