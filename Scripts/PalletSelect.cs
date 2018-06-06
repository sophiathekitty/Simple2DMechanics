using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PalletSelect : MonoBehaviour {
    public PalletDatabase palletDatabase;
    public Button[] options;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < palletDatabase.pallets.Length; i++)
        {
            if(i < options.Length)
            {
                TextMeshProUGUI text = options[i].transform.GetComponentInChildren<TextMeshProUGUI>();
                if (text != null)
                    text.SetText(palletDatabase.pallets[i].name);
            }
                
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // select a pallet

    public void SetPallet(int pallet)
    {

        palletDatabase.currentPallet = pallet;
        Debug.Log(pallet);
        PalletSwap swap = (PalletSwap)GameObject.FindObjectOfType(typeof(PalletSwap));
        if (swap != null)
            swap.SwapPallets();
        Debug.Log(swap);
    }
}
