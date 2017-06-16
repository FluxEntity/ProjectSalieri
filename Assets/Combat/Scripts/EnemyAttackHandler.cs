using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour {

    List<Enemy> Attackers;
    int beatsTillNext;
    public Transform playerSplash;
    public Transform enemySplash;
    public Transform attack;
    public int beatsPassed;
    public int attackBeats;
    AudioBehavior audioRef;
    public float attackVelocity;
    public float attackAcceleration;

    enum states
    {
        BEGIN,
        SPLASH,
        WAITFORBAR,
        LAUNCH,
        POSITION,
        IDLE,
    }

    states currentState;

	// Use this for initialization
	void Start () {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        currentState = states.BEGIN;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (currentState)
        {
            case (states.BEGIN):
                playerSplash = Instantiate(playerSplash);
                enemySplash = Instantiate(enemySplash);
                playerSplash.position = new Vector3(19, playerSplash.position.y, playerSplash.position.z);
                enemySplash.position = new Vector3(-19, enemySplash.position.y, enemySplash.position.z);
                currentState = states.SPLASH;
                break;
            case (states.SPLASH):
                if(playerSplash.position.x > 0)
                {
                    playerSplash.position = new Vector3(playerSplash.position.x -0.5f, playerSplash.position.y, playerSplash.position.z);
                    enemySplash.position = new Vector3(enemySplash.position.x + 0.5f, enemySplash.position.y, enemySplash.position.z);
                }
                else
                {
                    currentState = states.WAITFORBAR;
                }
                break;
            case (states.WAITFORBAR):
                if (audioRef.bar)
                    currentState = states.LAUNCH;
                break;
            case (states.LAUNCH):
                print("INSTANTIATETIME: " + audioRef.trackTime);
                attack = Instantiate(attack, new Vector3(attack.position.x, 12, attack.position.z), attack.rotation);
                 attackVelocity = 0;
                //attackVelocity = (12f / (audioRef.moddedSPB * audioRef.BPB/2));
                
                currentState = states.POSITION;
                break;
            case (states.POSITION):
                if(attack.position.y > 5.9f)
                {
                    attackVelocity = attackVelocity + (12f / (audioRef.moddedSPB*audioRef.moddedSPB*audioRef.BPB*audioRef.BPB/4f)) * Time.deltaTime;
                    attack.position = new Vector3(attack.position.x, Mathf.Max(5.9f, attack.position.y - attackVelocity * Time.deltaTime), attack.position.z);
                }
                else if(attack.position.y > 0)
                {
                    attackVelocity = Mathf.Max(0.1f, attackVelocity - (12f / (audioRef.moddedSPB * audioRef.moddedSPB * audioRef.BPB * audioRef.BPB / 4f)) * Time.deltaTime);
                    attack.position = new Vector3(attack.position.x, Mathf.Max(0, attack.position.y - attackVelocity * Time.deltaTime), attack.position.z);
                }
               /* if(attack.position.y > 6)
                {
                    attackVelocity = attackVelocity + (12f / ((audioRef.BPB *audioRef.BPB/4f)*audioRef.moddedSPB * audioRef.moddedSPB)) / (60f*60f);
                    //distance to travel = 12. y_new = y_cur - (12units/SPB)/60fps)/3beats)
                    attack.position = new Vector3(attack.position.x, Mathf.Max(0, attack.position.y - attackVelocity), attack.position.z);
                }
                else if(attack.position.y > 0) {
                    attackVelocity = Mathf.Max(0, attackVelocity - (12f / ((audioRef.BPB * audioRef.BPB / 4f) * audioRef.moddedSPB * audioRef.moddedSPB)) / (60f * 60f));
                    //distance to travel = 12. y_new = y_cur - (12units/SPB)/60fps)/3beats)
                    attack.position = new Vector3(attack.position.x, Mathf.Max(0, attack.position.y - attackVelocity), attack.position.z);
                }*/
                break;
        }
	}
}
