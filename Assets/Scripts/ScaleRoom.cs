using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRoom : MonoBehaviour {

    public GameObject kambarys;
    Vector3 size = new Vector3(10, 10, 10);
    public void Start()
    {
        GetParameters();
    }
    public void GetParameters()
    {
        float width = (float)0.1*PlayerPrefs.GetFloat("width");
        float height = (float)0.1 * PlayerPrefs.GetFloat("height");
        float length = (float)0.1 * PlayerPrefs.GetFloat("length");
        size = new Vector3(width, height, length);
        Debug.Log(size);
        kambarys.transform.position = new Vector3(0, 0, 0);
        kambarys.transform.localScale = size;

    }
}
