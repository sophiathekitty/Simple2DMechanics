using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathTracker : MonoBehaviour {
    public IntVariable deaths;
    public bool resetTimeOnStart;
    TextMeshProUGUI text;
    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();
        if (resetTimeOnStart)
            deaths.RuntimeValue = 0;
        text.text = deaths.RuntimeValue.ToString();
    }
    public void OnPlayerDeath()
    {
        deaths.RuntimeValue++;
        if (text != null)
            text.text = deaths.RuntimeValue.ToString();
    }
}
