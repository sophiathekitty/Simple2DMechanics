using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletSwap : MonoBehaviour {

    public PalletDatabase palletDatabase;

	// Use this for initialization
	void Awake () {
        SwapPallets();
	}

    public void SwapPallets()
    {
        if (palletDatabase != null)
        {
            ColorLayer[] layers = (ColorLayer[])Resources.FindObjectsOfTypeAll(typeof(ColorLayer));
            foreach(ColorLayer layer in layers)
            {
                layer.pallet = palletDatabase.pallet;
                layer.ApplyPallet();
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
