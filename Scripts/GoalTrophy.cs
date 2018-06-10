using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using UnityEngine.SceneManagement;

public class GoalTrophy : MonoBehaviour {
    public int trophyID;
    public BoolVariable trophyUnlocked;
    public int level25;
    public BoolVariable trophy25Unlocked;
    public int level50;
    public BoolVariable trophy50Unlocked;
    public int level75;
    public BoolVariable trophy75Unlocked;
    public IntVariable currentLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameJoltAPI.Instance.CurrentUser == null)
            return;
        Scene scene = SceneManager.GetActiveScene();
        if (currentLevel.RuntimeValue == 24 && !trophy25Unlocked.RuntimeValue)
            Trophies.Unlock(level25, (bool success) => {
                trophy25Unlocked.RuntimeValue = success;
                if (success)
                {
                    Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Something went wrong");
                }
            });

        if (currentLevel.RuntimeValue == 49 && !trophy50Unlocked.RuntimeValue)
            Trophies.Unlock(level50, (bool success) => {
                trophy50Unlocked.RuntimeValue = success;
                if (success)
                {
                    //Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Something went wrong");
                }
            });

        if (currentLevel.RuntimeValue == 74 && !trophy75Unlocked.RuntimeValue)
            Trophies.Unlock(level75, (bool success) => {
                trophy75Unlocked.RuntimeValue = success;
                if (success)
                {
                    //Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Something went wrong");
                }
            });

        if (collision.tag == "Player" && trophyID > 0 && !trophyUnlocked.RuntimeValue)
        {

            Trophies.Unlock(trophyID, (bool success) => {
                trophyUnlocked.RuntimeValue = success;
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
    }
}
