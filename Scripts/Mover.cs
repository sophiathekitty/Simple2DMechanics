using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public Transform startPoint;
    public Transform endPoint;
    public Transform[] objects;
    public float time = 3f;
    public AnimationCurve curve = new AnimationCurve();
    private float[] percent;
	// Use this for initialization
	void Start () {
        percent = new float[objects.Length];
        for(int i = 0; i < percent.Length; i++)
            percent[i] = (1f / objects.Length)*i;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < percent.Length; i++)
        {
            percent[i] += Time.deltaTime / time;
            if (percent[i] > 1)
                percent[i] -= 1;
            objects[i].position = Vector3.Lerp(startPoint.position, endPoint.position, curve.Evaluate(percent[i]));
        }
	}
}
