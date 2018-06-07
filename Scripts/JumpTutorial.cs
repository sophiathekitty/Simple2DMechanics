using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorial : MonoBehaviour {
    public enum JumpDir { Left, Right }
    public JumpDir jumpDirerction;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("JumpLeft") && jumpDirerction == JumpDir.Left)
        {
            Debug.Log("Jump Left");
            animator.SetInteger("Jumps", animator.GetInteger("Jumps") + 1);
        }
        if (Input.GetButtonDown("JumpRight") && jumpDirerction == JumpDir.Right)
        {
            Debug.Log("Jump Right");
            animator.SetInteger("Jumps", animator.GetInteger("Jumps") + 1);
        }
    }
}
