using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    private Scene currentScene;
	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
    }
    // level complete
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            else
                SceneManager.LoadScene(0);
        }
    }
}
