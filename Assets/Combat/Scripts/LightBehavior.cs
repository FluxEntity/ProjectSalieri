using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour {

    Animator anim;
    string notekey;
    string objectname;
    AudioBehavior audioRef;

    // Use this for initialization
    void Start () {
        objectname = gameObject.name;
        anim = GetComponent<Animator>();
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
        if (objectname == "BeatLight")
        {
            anim.SetBool("Pressed", audioRef.beat);
        }
        else
        {
            anim.SetBool("Pressed", audioRef.bar);
        }
	}
}
