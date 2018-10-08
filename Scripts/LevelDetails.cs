using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LevelDetails : ScriptableObject {
    public string level_name;
    public int buildIndex;
    public float average_deaths;
    public float average_cleartime;
    public int keys;
    public int attackers;
    public int hazards;
    public int moving_hazards;
    public int rotating = 0;

    public float level_rank
    {
        get
        {
            return (average_cleartime/100) * (average_deaths + 0.0001f);
        }
    }
    public float level_rank2
    {
        get
        {
            return keys + attackers + hazards + moving_hazards + rotating;
        }
    }
    public float level_rank3
    {
        get
        {
            return (keys+1) * (attackers+1) * (hazards+1) * (moving_hazards+1) * (rotating+1);
        }
    }
    public float level_rank4
    {
        get
        {
            return (level_rank + level_rank2);
        }
    }
    public float level_rank5
    {
        get
        {
            return level_rank + level_rank3;
        }
    }
    public float level_rank6
    {
        get
        {
            return (level_rank4 + level_rank5)/2;
        }
    }
    public float level_rank7
    {
        get
        {
            return buildIndex;
        }
    }


}
