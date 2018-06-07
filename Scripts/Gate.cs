using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    public bool resetOnDeath = true;
    private bool gatePassed = false;
    public BoxCollider2D boxCollider;
    private Dictionary<Key,bool> keys = new Dictionary<Key, bool>();
    private float startHeight;
    private float targetHeight;
    // unlocked
    public bool Unlocked
    {
        get
        {
            foreach (KeyValuePair<Key, bool> key in keys)
                if (!key.Value)
                    return false;
            return true;
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
    public void AddKey(Key key)
    {
        if (keys.ContainsKey(key))
            keys[key] = false;
        else
            keys.Add(key, false);
        Debug.Log(key);
    }
    // key found
	public void KeyFound(Key key)
    {
        if (keys.ContainsKey(key))
            keys[key] = true;
        if (!Unlocked)
            return;
        targetHeight = 0.1f;
        boxCollider.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Unlocked)
        {
            Debug.Log("gate passed");
            targetHeight = 0f;
            gatePassed = true;
        }
    }

    // player dead
    public void OnPlayerDead()
    {
        Debug.Log(gatePassed);
        if (!resetOnDeath || gatePassed)
            return;
        boxCollider.enabled = true;
        targetHeight = startHeight;
        boxCollider.transform.localScale = new Vector3(boxCollider.transform.localScale.x, targetHeight, boxCollider.transform.localScale.z);
        Debug.Log(keys.Count);
        foreach (KeyValuePair<Key, bool> key in keys)
        {
            if(keys.ContainsKey(key.Key))
                keys[key.Key] = false;
            key.Key.gameObject.SetActive(true);
        }
    }
}
