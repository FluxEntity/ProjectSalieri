using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseToBeat : MonoBehaviour {

    AudioBehavior audioRef;
    SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
        if (audioRef.beat)
        {
            sr.color = new Color(Mathf.Min(1f, sr.color.r + 0.02f), Mathf.Min(1f, sr.color.g + 0.02f), Mathf.Min(1f, sr.color.b + 0.02f), 1f);
        }
        else
        {
            sr.color = new Color(Mathf.Max(0.9f, sr.color.r - 0.005f), Mathf.Max(0.9f, sr.color.g - 0.005f), Mathf.Max(0.9f, sr.color.b - 0.005f), 255f);
        }
	}
}
