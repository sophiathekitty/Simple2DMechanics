using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    public bool resetOnDeath = true;
    private bool gatePassed = false;
    public BoxCollider2D boxCollider;
    private Key key;
    private bool locked = true;
    private float startHeight;
    private float targetHeight;
    // unlocked
    public bool Unlocked
    {
        get
        {
            return !locked;
        }
    }
    // Use this for initialization
    void Start () {

        //boxCollider = GetComponentInChildren<BoxCollider2D>();
        targetHeight = startHeight = boxCollider.transform.localScale.y;
	}
    // update
    private void Update()
    {
        boxCollider.transform.localScale = new Vector3(boxCollider.transform.localScale.x, Mathf.Lerp(boxCollider.transform.localScale.y, targetHeight,Time.deltaTime), boxCollider.transform.localScale.z);
    }
    // add key
    public void AddKey(Key ky)
    {
        key = ky;
        locked = true;
    }
    // key found
	public void KeyFound(Key key)
    {
        locked = false;
        targetHeight = 0.1f;
        boxCollider.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Unlocked)
        {
            targetHeight = 0f;
            gatePassed = true;
        }
    }

    // player dead
    public void OnPlayerDead()
    {
        if (!resetOnDeath || gatePassed)
            return;
        boxCollider.enabled = true;
        targetHeight = startHeight;
        boxCollider.transform.localScale = new Vector3(boxCollider.transform.localScale.x, targetHeight, boxCollider.transform.localScale.z);
        locked = true;
        key.gameObject.SetActive(true);
    }
}
