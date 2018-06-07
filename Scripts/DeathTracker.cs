using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathTracker : MonoBehaviour {
    public IntVariable deaths;
    public bool resetTimeOnStart;
    TextMeshProUGUI text;
    TextMeshPro text2;
    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();
        text2 = GetComponent<TextMeshPro>();
        if (resetTimeOnStart)
            deaths.RuntimeValue = 0;
        if (text != null)
            text.text = deaths.RuntimeValue.ToString();
        else if (text2 != null)
            text2.text = deaths.RuntimeValue.ToString();
    }
    public void OnPlayerDeath()
    {
        deaths.RuntimeValue++;
        Debug.Log("player dead");
        if (text != null)
            text.text = deaths.RuntimeValue.ToString();
        else if (text2 != null)
            text2.text = deaths.RuntimeValue.ToString();
    }
}
