﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour {
    AudioBehavior audioRef;

	// Use this for initialization
	void Start () {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.moddedNoteVelocity, 0);
	}
	
	//Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.moddedNoteVelocity, 0);
    }
}
