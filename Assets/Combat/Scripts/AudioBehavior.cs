using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehavior : MonoBehaviour {

    AudioSource source;
    public float BPB; //Beats Per Bar
    public float moddedBPM;
    public float BPM; //Beats Per Minute
    public float SPB; //Seconds Per Beat
    public float moddedSPB;
    public float beatCount; // beatCount (from 1 to BPB)
    public float trackTime; //current playhead position
    public bool beat; //is on downbeat?
    public bool bar; //is on downbeat of beat 1?
    public bool wait;
    public float moddedNoteVelocity;
    public float noteVelocity;

    void Start () {
        BPM = 180f; //predetermined
        moddedBPM = BPM;
        SPB = 60f / BPM;
        moddedSPB = SPB;
        BPB = 4; //predetermined
        beatCount = 1;
        source = GetComponent<AudioSource>();
        wait = false;
        noteVelocity = 4f; //predetermined
        moddedNoteVelocity = noteVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        //BPM = baseBPM * source.pitch;
        SPB = 60f / BPM;
        moddedNoteVelocity = noteVelocity * source.pitch;
        moddedBPM = BPM * source.pitch;
        moddedSPB = 60f / moddedBPM;
        trackTime = source.time;
        beat = (trackTime % SPB < 0.05 || trackTime % SPB > SPB - 0.01);
        bar = (trackTime % (SPB * BPB) < 0.05 || trackTime % (SPB*BPB) > (SPB*BPB) - 0.01);
            if(!wait && bar)
        {
            beatCount = 1;
            //print(beatCount); debug
        }
        else if (!wait && beat)
        {
            beatCount++;
            //print(beatCount); debug
        }
        wait = beat;
    }
}
