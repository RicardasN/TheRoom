using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SelectFurnitureToAdd(int index)
    {
        //0-sofa 1-kede 2-stalas 3-televizorius
        PlayerPrefs.SetInt("FurnitureSelected", index);
        PlayerPrefs.Save();
    }
}
