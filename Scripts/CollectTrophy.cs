using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class CollectTrophy : MonoBehaviour {
    public int trophyID;
    public BoolVariable trophyUnlocked;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Unlock();
        }
    }
    public void Unlock()
    {
        if (GameJoltAPI.Instance.CurrentUser == null)
            return;
        if (trophyID > 0 && !trophyUnlocked.RuntimeValue)
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
