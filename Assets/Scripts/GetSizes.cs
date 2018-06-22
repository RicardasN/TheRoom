using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSizes : MonoBehaviour {

    public InputField textField;

    public double length = 10, width = 10, height = 10;
    public void GetParameters()
    {
        //Debug.Log(textField.text);
        if (textField.text != null)
        {
            string[] temp = textField.text.Split('X', 'x');
            if (temp != null && temp.Length > 0)
            {
                length = Convert.ToDouble(temp[0]);
                width = Convert.ToDouble(temp[1]);
                if (temp.Length > 2)
                    height = Convert.ToDouble(temp[2]);
            }
        }
        PlayerPrefs.SetFloat("length", (float)length);
        PlayerPrefs.SetFloat("width", (float)width);
        PlayerPrefs.SetFloat("height", (float)height);
        PlayerPrefs.Save();
    }
    
}
