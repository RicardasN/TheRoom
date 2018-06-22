using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialOptions : MonoBehaviour {

    public Dropdown materialsDropdown;
    private Material[] materials;
    private int value;
    // Use this for initialization
    void Start () {

        MeshRenderer m = GetComponent<MeshRenderer>();
        materials = m.materials; ;
        materialsDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < materials.Length; i += 2)
        {
            string option = materials[i].name;
            options.Add(option);

        }
        materialsDropdown.AddOptions(options);
        materialsDropdown.value = 0;
        value = 0;
        PlayerPrefs.SetInt("material", value);
        PlayerPrefs.Save();
        materialsDropdown.RefreshShownValue();
    }
    public void SetMaterial(int index)
    {
        value = index;
        PlayerPrefs.SetInt("material", value);
        PlayerPrefs.Save();
    }

}
