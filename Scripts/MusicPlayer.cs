using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    public AudioClip intro;
    public AudioClip[] tracks;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(intro);
	}
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(RandomTrack());
	}

    AudioClip RandomTrack()
    {
        return tracks[(int)Random.Range(0, tracks.Length-1)];
    }
}
