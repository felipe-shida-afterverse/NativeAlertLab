package com.example.test;

import android.content.Context;
import com.lab.NativeDialog;

public class NativeDialogInterface
{
    public static void displayDialog(Context context, String text)
    {
        NativeDialog.INSTANCE.displayToast(context, text);
    }
}