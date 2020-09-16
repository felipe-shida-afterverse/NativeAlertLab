#if UNITY_ANDROID
using Plugins.Android;
#endif
#if UNITY_IOS
using Plugins.iOS;
#endif
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AlertSender : MonoBehaviour
{
    private Button sendToastButton;
    [SerializeField] string dialogTitle;
    [SerializeField] string toastString;
    [SerializeField] string toastLength;

    private void Start()
    {
        sendToastButton = GetComponent<Button>();
        sendToastButton.onClick.AddListener(SendToast);
    }

    public void SendToast()
    {
#if UNITY_ANDROID
        AndroidToastSender toastSender = new AndroidToastSender(toastString, toastLength);
        StartCoroutine(toastSender.RunToastOnUIThreadAndroid());
#elif UNITY_IOS
        StartCoroutine(iOSNativeAlert.RuniOSDialog(dialogTitle, toastString));
#endif
    }

    
}
