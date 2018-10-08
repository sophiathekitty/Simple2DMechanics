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
    public bool skip_goal;
    public GameObject skip_wall;
    public int deaths_to_skip = 10;
	// Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene();
        level = playlist.GetLevel(currentScene.name);
        level.buildIndex = currentScene.buildIndex;
        RemoteSettingsHolder rsh = GameObject.FindObjectOfType<RemoteSettingsHolder>();
        if (rsh != null)
        {
            deaths_to_skip = rsh.DeathsToSkip;
            Debug.Log("Deaths To Skip Updated: " + deaths_to_skip);
        }
        if (skip_goal)
            return;
        Key[] keys = GameObject.FindObjectsOfType<Key>();
        level.keys= keys.Length;
        Hazard[] hazards = GameObject.FindObjectsOfType<Hazard>();
        level.hazards = hazards.Length;
        Attacker[] attackers = GameObject.FindObjectsOfType<Attacker>();
        level.attackers = attackers.Length;
        Mover[] movers = GameObject.FindObjectsOfType<Mover>();
        level.moving_hazards = movers.Length;
        foreach(Mover mover in movers)
        {
            level.moving_hazards += mover.objects.Length;
        }

    }
    public void OnPlayerDead()
    {
        deaths++;
        Debug.Log("Goal:OnPlayerDead");
        Debug.Log("Deaths:" + deaths);
        Debug.Log("Deaths to skip:" + deaths_to_skip);
        if (skip_goal && deaths >= deaths_to_skip)
            skip_wall.SetActive(false);
    }
    // level complete
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ColorLayer color = GetComponent<ColorLayer>();

            if (skip_goal)
                AnalyticsEvent.Custom("level_skipped", new Dictionary<string, object>
                {
                    { "build_index", currentLevel.RuntimeValue },
                    { "scene_name", currentScene.name },
                    { "deaths", deaths },
                    { "pallet", color.pallet.name },
                    { "time_to_clear", Time.timeSinceLevelLoad }
                });
            else
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
