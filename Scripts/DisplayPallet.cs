using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayPallet : MonoBehaviour {
    private ColorLayer layer;
    private TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        layer = GetComponent<ColorLayer>();
        text = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        if(layer.pallet.name != "Default")
            text.text = layer.pallet.name;
        else
            text.text = "";
    }
}
