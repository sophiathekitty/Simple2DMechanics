using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColorPallet : ScriptableObject {
    public Gradient background;
    public Gradient walls;
    public Gradient player;
    public Gradient highlight;
    public Gradient hazard;
    public Gradient gate;

    public enum Layer {background,walls,player,highlight,hazard,gate}
    public Color GetColor(Layer layer, float time = 0)
    {
        Debug.Log(time);
        switch (layer)
        {
            case Layer.walls:
                return walls.Evaluate(time);
            case Layer.player:
                return player.Evaluate(time);
            case Layer.highlight:
                return highlight.Evaluate(time);
            case Layer.hazard:
                return hazard.Evaluate(time);
            case Layer.gate:
                return gate.Evaluate(time);
        }
        return background.Evaluate(time);
    }
}
