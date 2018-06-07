using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class Goal : MonoBehaviour {
    private Scene currentScene;
    private int deaths;
	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
    }
    public void OnPlayerDead()
    {
        deaths++;
    }
    // level complete
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ColorLayer color = GetComponent<ColorLayer>();

            AnalyticsEvent.Custom("goal_reached", new Dictionary<string, object>
            {
                { "build_index", currentScene.buildIndex },
                { "scene_name", currentScene.name },
                { "deaths", deaths },
                { "pallet", color.pallet.name },
                { "time_to_clear", Time.timeSinceLevelLoad }
            });
            if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            else
                SceneManager.LoadScene(0);
        }
    }
}
