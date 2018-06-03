using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChange : MonoBehaviour {
    public Vector3 sizeA;
    public Vector3 sizeB;
    private bool direction;
    private float percent = 0;
    public enum LoopStyle { Loop, PingPong, OneShot }
    public LoopStyle style;
    public float time = 1;
    public AnimationCurve curve;

    // Use this for initialization
    void Start () {
        direction = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (direction)
            percent += Time.deltaTime / time;
        else
            percent -= Time.deltaTime / time;

        switch (style)
        {
            case LoopStyle.Loop:
                if (percent >= 1)
                    percent = 0;
                break;
            case LoopStyle.PingPong:
                if (percent >= 1)
                    direction = false;
                if (percent <= 0)
                    direction = true;
                break;
        }
        transform.localScale = Vector3.Lerp(sizeA,sizeB,curve.Evaluate(percent));
	}
}
