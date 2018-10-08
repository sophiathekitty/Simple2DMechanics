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
        // find levels
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
        // sort levels
        if(GUILayout.Button("Sort Levels"))
        {
            /*
            foreach (LevelDetails lvl in playlist.levels)
            {
                Debug.Log(lvl.level_name + ": " +lvl.level_rank.ToString());
            }
            */
            //
            CompLevel compLevel = new CompLevel();
            playlist.levels.Sort(comparer: compLevel);
            playlist.SavePlaylistToChild(0);

            CompLevel2 compLevel2 = new CompLevel2();
            playlist.levels.Sort(comparer: compLevel2);
            playlist.SavePlaylistToChild(1);

            CompLevel3 compLevel3 = new CompLevel3();
            playlist.levels.Sort(comparer: compLevel3);
            playlist.SavePlaylistToChild(2);

            CompLevel4 compLevel4 = new CompLevel4();
            playlist.levels.Sort(comparer: compLevel4);
            playlist.SavePlaylistToChild(3);

            CompLevel5 compLevel5 = new CompLevel5();
            playlist.levels.Sort(comparer: compLevel5);
            playlist.SavePlaylistToChild(4);

            CompLevel6 compLevel6 = new CompLevel6();
            playlist.levels.Sort(comparer: compLevel6);
            playlist.SavePlaylistToChild(5);

            CompLevel7 compLevel7 = new CompLevel7();
            playlist.levels.Sort(comparer: compLevel7);
            playlist.SavePlaylistToChild(6);

            EditorUtility.SetDirty(playlist);
        }

        if (GUILayout.Button("Playlist 0"))
        {
            playlist.LoadPlaylist(0);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 1"))
        {
            playlist.LoadPlaylist(1);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 2"))
        {
            playlist.LoadPlaylist(2);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 3"))
        {
            playlist.LoadPlaylist(3);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 4"))
        {
            playlist.LoadPlaylist(4);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 5"))
        {
            playlist.LoadPlaylist(5);
            EditorUtility.SetDirty(playlist);
        }
        if (GUILayout.Button("Playlist 6"))
        {
            playlist.LoadPlaylist(6);
            EditorUtility.SetDirty(playlist);
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
public class CompLevel2 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank2 > y.level_rank2)
                    return 1;
                else if (x.level_rank2 < y.level_rank2)
                    return -1;
            }
        }
        return 0;
    }
}
public class CompLevel3 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank3 > y.level_rank3)
                    return 1;
                else if (x.level_rank3 < y.level_rank3)
                    return -1;
            }
        }
        return 0;
    }
}
public class CompLevel4 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank4 > y.level_rank4)
                    return 1;
                else if (x.level_rank4 < y.level_rank4)
                    return -1;
            }
        }
        return 0;
    }
}
public class CompLevel5 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank5 > y.level_rank5)
                    return 1;
                else if (x.level_rank5 < y.level_rank5)
                    return -1;
            }
        }
        return 0;
    }
}
public class CompLevel6 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank6 > y.level_rank6)
                    return 1;
                else if (x.level_rank6 < y.level_rank6)
                    return -1;
            }
        }
        return 0;
    }
}
public class CompLevel7 : IComparer<LevelDetails>
{
    public int Compare(LevelDetails x, LevelDetails y)
    {
        if (x == null)
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
                if (x.level_rank7 > y.level_rank7)
                    return 1;
                else if (x.level_rank7 < y.level_rank7)
                    return -1;
            }
        }
        return 0;
    }
}