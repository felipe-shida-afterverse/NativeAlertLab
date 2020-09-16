using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToastSender : MonoBehaviour
{
    private const string UNITY_PLAYER_CLASS_PACKAGE = "com.unity3d.player.UnityPlayer";
    private Button sendToastButton;
    [SerializeField] string dialogTitle;
    [SerializeField] string toastString;
    [SerializeField] string toastLength;
    
    AndroidJavaObject currentActivity;

    private void Start()
    {
        sendToastButton = GetComponent<Button>();
        sendToastButton.onClick.AddListener(SendToast);
    }

    public void SendToast()
    {
#if UNITY_ANDROID
        StartCoroutine(RunToastOnUIThreadAndroid());
#elif UNITY_IOS
        StartCoroutine(RuniOSDialog());
#endif
    }

    [DllImport("__Internal")]
    private static extern void ShowAlert(string title, string message);

    private IEnumerator RuniOSDialog()
    {
        ShowAlert(dialogTitle, toastString);
        
        yield return null;
    }

    private IEnumerator RunToastOnUIThreadAndroid()
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass(UNITY_PLAYER_CLASS_PACKAGE); 
     
        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (ShowToast));

        yield return null;
    }

    private void ShowToast()
    {
        Debug.Log ("Running on UI thread");
        object[] toastParams = new object[3];
        
        toastParams[0] = currentActivity;
        toastParams[1] = toastString;

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        
        toastParams[2] = Toast.GetStatic<int> (toastLength);
        
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", toastParams);

        toast.Call ("show");
    }
}
