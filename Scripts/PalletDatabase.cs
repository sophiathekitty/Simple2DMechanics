using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PalletDatabase : ScriptableObject {
    public int currentPallet;
    public ColorPallet[] pallets;
    public ColorPallet pallet
    {
        get
        {
            if (currentPallet >= pallets.Length)
                currentPallet = 0;
            if (currentPallet < pallets.Length)
                return pallets[currentPallet];
            return null;
        }
    }
}
