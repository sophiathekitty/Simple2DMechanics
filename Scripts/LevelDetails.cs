using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDetails : ScriptableObject {
    public string level_name;
    public int buildIndex;
    public float average_deaths;
    public float average_cleartime;

    public float level_rank
    {
        get
        {
            return (average_cleartime/100) * (average_deaths + 0.0001f);
        }
    }
}
