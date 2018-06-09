using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class FinalScore : MonoBehaviour {
    public int trophyID;
    public int timerScoreID;
    public int deathsScoreID;
    public FloatVariable currentTime;
    public FloatVariable bestTime;
    public BoolVariable completed;
    public IntVariable deathCount;
	// Use this for initialization
	void Awake () {
        int scoreValue = (int)(currentTime.RuntimeValue * 100); // The actual score.
        string scoreText = FormatTime(currentTime.RuntimeValue); // A string representing the score to be shown on the website.
        string extraData = ""; // This will not be shown on the website. You can store any information.
        if (GameJoltAPI.Instance.CurrentUser != null)
            GameJolt.API.Scores.Add(scoreValue, scoreText, timerScoreID, extraData, (bool success) => {
                Debug.Log(string.Format("Time Score Add {0}.", success ? "Successful" : "Failed"));
            });
        scoreValue = deathCount.RuntimeValue; // The actual score.
        scoreText = string.Format("{0} splats",deathCount.RuntimeValue); // A string representing the score to be shown on the website.
        extraData = ""; // This will not be shown on the website. You can store any information.
        if (GameJoltAPI.Instance.CurrentUser != null)
            GameJolt.API.Scores.Add(scoreValue, scoreText, deathsScoreID, extraData, (bool success) => {
                Debug.Log(string.Format("Death Score Add {0}.", success ? "Successful" : "Failed"));
            });

        if (bestTime.RuntimeValue > currentTime.RuntimeValue || bestTime.RuntimeValue >= 0f)
        {
            bestTime.RuntimeValue = currentTime.RuntimeValue;
        }

        if (GameJoltAPI.Instance.CurrentUser == null)
            return;

        if (!completed.RuntimeValue)
        {
            Trophies.Unlock(trophyID, (bool success) => {
                completed.RuntimeValue = success;
                if (success)
                {
                    Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Something went wrong");
                }
            });
        }
        completed.RuntimeValue = true;
    }

    public string FormatTime(float time)
    {
        string txt = "";
        float hours = Mathf.Floor(time / (60 * 60));
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
