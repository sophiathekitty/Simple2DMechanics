using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PalletDatabase : ScriptableObject {
    public IntVariable currentPallet;
    public ColorPallet[] pallets;
    public ColorPallet pallet
    {
        get
        {
            if (currentPallet.RuntimeValue >= pallets.Length)
                currentPallet.RuntimeValue = 0;
            if (currentPallet.RuntimeValue < pallets.Length)
                return pallets[currentPallet.RuntimeValue];
            return null;
        }
    }
}
