using System.Collections;
using System.Runtime.InteropServices;

namespace Plugins.iOS
{
    public class iOSNativeAlert
    {
        [DllImport("__Internal")]
        private static extern void ShowAlert(string title, string message);

        public static IEnumerator RuniOSDialog(string dialogTitle, string toastString)
        {
            ShowAlert(dialogTitle, toastString);
        
            yield return null;
        }
    }
}