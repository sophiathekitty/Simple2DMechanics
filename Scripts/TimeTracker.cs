using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour {
    public FloatVariable secondsPlayed;
    public bool resetTimeOnStart;
    public bool trackTime = true;
    TextMeshProUGUI text;
    TextMeshPro text2;
    // Use this for initialization
    void Start () {
        text = GetComponent<TextMeshProUGUI>();
        text2 = GetComponent<TextMeshPro>();
        if (resetTimeOnStart)
            secondsPlayed.RuntimeValue = 0;
        if (text != null)
            text.text = FormatTime(secondsPlayed.RuntimeValue);
        else if (text2 != null)
            text2.text = FormatTime(secondsPlayed.RuntimeValue);
    }

    // Update is called once per frame
    void Update () {
        if(trackTime)
            secondsPlayed.RuntimeValue += Time.deltaTime;
        if (text != null)
            text.text = FormatTime(secondsPlayed.RuntimeValue);
        else if (text2 != null)
            text2.text = FormatTime(secondsPlayed.RuntimeValue);
    }

    public string FormatTime(float time)
    {
        string txt = "";
        float hours = Mathf.Floor(time / (60*60));
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.RoundToInt(time % 60);
        if (hours > 0)
            txt += hours.ToString() + ":";
        if (minutes < 10)
            txt += "0" + minutes.ToString();
        else
            txt += minutes.ToString();
        txt += ":";
        if (seconds < 10)
            txt += "0" + Mathf.RoundToInt(seconds).ToString();
        else
            txt += Mathf.RoundToInt(seconds).ToString();
        return txt;
    }
}
