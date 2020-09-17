#if UNITY_ANDROID
    using Plugins.Android;
#endif
#if UNITY_IOS
using Plugins.iOS;
#endif

using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class BundleVersionDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();

        string bundleCode;
        
#if UNITY_EDITOR
            bundleCode = "EDITOR";
#elif UNITY_ANDROID
        bundleCode = AndroidBundleVersionCode.BundleCode;
#elif UNITY_IOS
        bundleCode = IOSBundleVersionCode.BundleCode;        
#endif
        
        text.text = $"Bundle version code: {bundleCode}";
    }
}
