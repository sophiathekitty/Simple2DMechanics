using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public Gate gate;
    private void Start()
    {
        gate.AddKey(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gate.KeyFound(this);
            gameObject.SetActive(false);
        }
    }
}
