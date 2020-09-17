package com.lab
import android.widget.Toast
import android.content.Context

object NativeDialog {
    
    fun displayToast(context: Context, text: String){
        val toast = Toast.makeText(context, text, Toast.LENGTH_LONG)
        toast.show()
    }
}