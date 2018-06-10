using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


[CustomEditor(typeof(LevelPlaylist))]
public class LevelPlaylistEditor : Editor {

    public LevelPlaylist playlist
    {
        get
        {
            return (LevelPlaylist)target;
        }
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Find Levels"))
        {
            Debug.Log(playlist.endLevel);
            // find all the levels
            playlist.levels.Clear();
            string[] scenes = AssetDatabase.FindAssets("t:Scene");
            string[] levels = AssetDatabase.FindAssets("t:LevelDetails");
            foreach(string lvl in levels)
            {
                LevelDetails level = (LevelDetails)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(lvl), typeof(LevelDetails));
                
                if (level.level_name != playlist.tutorial.level_name && level.level_name != playlist.endLevel.level_name)
                {
                    playlist.levels.Add(level);
                }
            }
            // find scenes in the levels folder and create level details
            foreach(string scene in scenes)
            {
                if (AssetDatabase.GUIDToAssetPath(scene).Contains("/Levels/"))
                {
                    string[] path = AssetDatabase.GUIDToAssetPath(scene).Split('/');
                    string lvl_path = "";
                    for(int i = 0; i < path.Length-1; i++)
                    {
                        lvl_path += path[i] + "/";
                    }
                    string level_name = path[path.Length - 1].Replace(".unity", "");
                    // see if the level already exists
                    bool level_missing = true;
                    foreach (LevelDetails lvld in playlist.levels)
                        if (lvld.level_name == level_name)
                            level_missing = false;
                    if (level_name == playlist.tutorial.level_name || level_name == playlist.endLevel.level_name)
                        level_missing = false;
                    if (level_missing)
                    {
                        LevelDetails olevel = (LevelDetails)AssetDatabase.LoadAssetAtPath(lvl_path + level_name + ".asset",typeof(LevelDetails));
                        if(olevel == null)
                        {
                            LevelDetails nLevel = ScriptableObject.CreateInstance<LevelDetails>();
                            nLevel.level_name = level_name;
                            nLevel.name = level_name;

                            AssetDatabase.CreateAsset(nLevel, lvl_path + level_name + ".asset");
                            if (!playlist.levels.Contains(nLevel))
                                playlist.levels.Add(nLevel);
                        }
                        else
                        {
                            if (!playlist.levels.Contains(olevel))
                                playlist.levels.Add(olevel);
                        }
                        EditorUtility.SetDirty(playlist);
                    }
                    
                }
            }

        }

        if(GUILayout.Button("Sort Levels"))
        {
            foreach(LevelDetails lvl in playlist.levels)
            {
                Debug.Log(lvl.level_name + ": " +lvl.level_rank.ToString());
            }
            CompLevel compLevel = new CompLevel();
            playlist.levels.Sort(comparer: compLevel);
        }
    }
}


public class CompLevel : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if(x == null)
        {
            if (y == null)
                return 0;
            else
                return -1;
        }
        else
        {
            if (y == null)
                return 1;
            else
            {
                if (x.level_rank > y.level_rank)
                    return 1;
                else if (x.level_rank < y.level_rank)
                    return -1;
            }
        }
        return 0;
    }
}