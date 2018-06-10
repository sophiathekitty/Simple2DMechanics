using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class LevelPlaylist : ScriptableObject {
    public LevelDetails tutorial;
    public LevelDetails endLevel;
    public List<LevelDetails> levels = new List<LevelDetails>();

    public string NextLevel(int currentLevel)
    {

        int c = currentLevel - 2;
        //Debug.Log("NextLevel: " + currentLevel.ToString() + " :: " + c.ToString());
        if (c < 0)
            return tutorial.level_name;
        if (c >= levels.Count)
            return endLevel.level_name;
        return levels[c].level_name;
    }

    public LevelDetails GetLevel(string level_name)
    {
        Debug.Log("GetLevel: " + level_name);

        if (level_name == tutorial.level_name)
            return tutorial;
        if (level_name == endLevel.level_name)
            return endLevel;

        foreach (LevelDetails level in levels)
            if (level.level_name == level_name)
                return level;
        return null;
    }

    public int GetIndex(string level_name)
    {
        if (level_name == tutorial.level_name)
            return 1;
        if (level_name == endLevel.level_name)
            return levels.Count+1;

        for(int i = 0; i < levels.Count; i++)
        {
            if (levels[i].level_name == level_name)
                return i+2;
        }
        
        return 0;
    }
}
