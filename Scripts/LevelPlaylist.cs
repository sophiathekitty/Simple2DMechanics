using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class LevelPlaylist : ScriptableObject {
    public LevelDetails tutorial;
    public LevelDetails endLevel;
    public List<LevelDetails> levels = new List<LevelDetails>();
    public List<LevelDetails> playlist0 = new List<LevelDetails>();
    public List<LevelDetails> playlist1 = new List<LevelDetails>();
    public List<LevelDetails> playlist2 = new List<LevelDetails>();
    public List<LevelDetails> playlist3 = new List<LevelDetails>();
    public List<LevelDetails> playlist4 = new List<LevelDetails>();
    public List<LevelDetails> playlist5 = new List<LevelDetails>();
    public List<LevelDetails> playlist6 = new List<LevelDetails>();

    public void SavePlaylistToChild(int index = -1)
    {

        List<LevelDetails> playlist = new List<LevelDetails>();
        foreach (LevelDetails level in levels)
            playlist.Add(level);
        switch (index)
        {
            case 0:
                playlist0 = playlist;
                break;
            case 1:
                playlist1 = playlist;
                break;
            case 2:
                playlist2 = playlist;
                break;
            case 3:
                playlist3 = playlist;
                break;
            case 4:
                playlist4 = playlist;
                break;
            case 5:
                playlist5 = playlist;
                break;
            case 6:
                playlist6 = playlist;
                break;
        }
    }
    public void LoadPlaylist(int index)
    {
        switch (index)
        {
            case 0:
                levels = playlist0;
                break;
            case 1:
                levels = playlist1;
                break;
            case 2:
                levels = playlist2;
                break;
            case 3:
                levels = playlist3;
                break;
            case 4:
                levels = playlist4;
                break;
            case 5:
                levels = playlist5;
                break;
            case 6:
                levels = playlist6;
                break;
        }

    }

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
            if (levels[i] == null)
                levels.RemoveAt(i);
            if (levels[i].level_name == level_name)
                return i+2;
        }
        
        return 0;
    }
}
