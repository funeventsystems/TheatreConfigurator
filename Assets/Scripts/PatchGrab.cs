using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PatchGrab : MonoBehaviour
{
    public Text patchGrabText;
    public string patchGrabString;

    // Start is called before the first frame update
    void Start()
    {
        reloadText();
    }

    public void reloadText()
    {
        patchGrabString = PlayerPrefs.GetString("DropdownValues");
        patchGrabText.text = patchGrabString;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
