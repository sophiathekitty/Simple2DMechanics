﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour {
    public float jumpHorizontal;
    public float jumpVirtical;
    public bool reloadOnDeath;
    public GameEvent onDeath;
    private Rigidbody2D rb;
    private Vector3 startPos;
    private ParticleSystem ps;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        startPos = new Vector3(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (rb == null)
            throw new System.MissingMemberException("RigidBody2D missing!");
        if (Input.GetButtonDown("JumpRight"))
            rb.velocity = new Vector2(jumpHorizontal, jumpVirtical);
        if (Input.GetButtonDown("JumpLeft"))
            rb.velocity = new Vector2(jumpHorizontal * -1, jumpVirtical);
        if (ps != null && (Input.GetButtonDown("JumpLeft") || Input.GetButtonDown("JumpRight")))
            ps.Play();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Hazard")
        {
            if (reloadOnDeath)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                transform.position = new Vector3(startPos.x, startPos.y);

            if (onDeath != null)
                onDeath.Raise();
        }
    }

}