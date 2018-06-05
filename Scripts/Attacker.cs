using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    public Transform hazard;
    public Transform target;
    private Vector3 startPos;
    public float attackTime;
    public AnimationCurve attackCurve;
    public float retreatTime;
    public AnimationCurve retreatCurve;
    public enum State { waiting, attacking, retreating}
    private State state;
    private float percent;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        state = State.waiting;
        Hazard h = GetComponentInChildren<Hazard>();
        if (h != null)
            hazard = h.transform;
        AttackGizmo t = GetComponentInChildren<AttackGizmo>();
        if (t != null)
            target = t.transform;
	}
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.attacking:
                percent += Time.deltaTime / attackTime;
                hazard.position = Vector3.Lerp(startPos, target.position, attackCurve.Evaluate(percent));
                if (percent >= 1)
                    state = State.retreating;
                break;
            case State.retreating:
                percent -= Time.deltaTime / retreatTime;
                hazard.position = Vector3.Lerp(startPos, target.position, retreatCurve.Evaluate(percent));
                if (percent <= 0)
                    state = State.waiting;
                break;
        }
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && state == State.waiting)
            state = State.attacking;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && state == State.waiting)
            state = State.attacking;
    }
}
