using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class Goal : MonoBehaviour {
    private Scene currentScene;
    private int deaths;
    public LevelPlaylist playlist;
    private LevelDetails level;
    public IntVariable currentLevel;

	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
        level = playlist.GetLevel(currentScene.name);
        level.buildIndex = currentScene.buildIndex;
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
                { "build_index", currentLevel.RuntimeValue },
                { "scene_name", currentScene.name },
                { "deaths", deaths },
                { "pallet", color.pallet.name },
                { "time_to_clear", Time.timeSinceLevelLoad }
            });
            level.average_cleartime = (level.average_cleartime+Time.timeSinceLevelLoad) / 2;
            level.average_deaths = (level.average_deaths + deaths) / 2;

            if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(playlist.NextLevel(currentLevel.RuntimeValue + 1));
            else
                SceneManager.LoadScene(0);
        }
    }
}
