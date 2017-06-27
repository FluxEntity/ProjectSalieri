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
    CombatStateMachine CSM;


    enum states
    {
        BEGIN,
        SPLASH,
        WAITFORBAR,
        LAUNCH,
        POSITION,
        IDLE,
        POSITIONNEXT,
        POSITIONLAST
    }

    states currentState;

	// Use this for initialization
	void Start () {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        CSM = GameObject.Find("BattleManager").GetComponent<CombatStateMachine>();
        currentState = states.BEGIN;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (currentState)
        {
            case (states.BEGIN):
                CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 2);
                playerSplash = Instantiate(playerSplash);
                enemySplash = Instantiate(enemySplash);
                playerSplash.position = new Vector3(19, playerSplash.position.y, playerSplash.position.z);
                enemySplash.position = new Vector3(-19, enemySplash.position.y, enemySplash.position.z);
                currentState = states.SPLASH;
                break;
            case (states.SPLASH):
                if(playerSplash.position.x > 0)
                {
                    playerSplash.position = new Vector3(playerSplash.position.x - 20 * (Time.deltaTime), playerSplash.position.y, playerSplash.position.z);
                    enemySplash.position = new Vector3(enemySplash.position.x + 20 * (Time.deltaTime), enemySplash.position.y, enemySplash.position.z);
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
                if(attack.GetComponent<PianoAttack>().move == true)
                {
                    currentState = states.POSITIONLAST;
                    attackVelocity = 0;
                }
                break;
            case (states.POSITIONNEXT):
                if (attack.position.x < 6.1f)
                {
                    attackVelocity = attackVelocity + (13f / (audioRef.moddedSPB * audioRef.moddedSPB * audioRef.BPB * audioRef.BPB / 4f)) * Time.deltaTime;
                    attack.position = new Vector3(attack.position.x + attackVelocity * Time.deltaTime, attack.position.y, attack.position.z);

                }
                else if (attack.position.x < 11f)
                {
                    attackVelocity = attackVelocity - (13f / (audioRef.moddedSPB * audioRef.moddedSPB * audioRef.BPB * audioRef.BPB / 4f)) * Time.deltaTime;
                    attack.position = new Vector3(attack.position.x + attackVelocity * Time.deltaTime, attack.position.y, attack.position.z);
                }
                else
                {
                    CombatStateMachine.currentState = CombatStateMachine.State.ENEMYDONE;
                    Destroy(gameObject);
                }
                break;
            case (states.POSITIONLAST):
                    if (attack.position.y > -6.1f)
                    {
                        attackVelocity = attackVelocity + (13f / (audioRef.moddedSPB * audioRef.moddedSPB * audioRef.BPB * audioRef.BPB / 4f)) * Time.deltaTime;
                        attack.position = new Vector3(attack.position.x, attack.position.y - attackVelocity * Time.deltaTime, attack.position.z);

                    }
                    else if (attack.position.y > -11f)
                    {
                        attackVelocity = attackVelocity - (13f / (audioRef.moddedSPB * audioRef.moddedSPB * audioRef.BPB * audioRef.BPB / 4f)) * Time.deltaTime;
                        attack.position = new Vector3(attack.position.x, attack.position.y - attackVelocity * Time.deltaTime, attack.position.z);
                    }
                    else
                    {
                    CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 0);
                        CombatStateMachine.currentState = CombatStateMachine.State.ENEMYDONE;
                        Destroy(gameObject);
                    }
                    if (playerSplash.position.x > -19f)
                    {
                        playerSplash.position = new Vector3(playerSplash.position.x + 20*(Time.deltaTime), playerSplash.position.y, playerSplash.position.z);
                        enemySplash.position = new Vector3(enemySplash.position.x - 20 * (Time.deltaTime), enemySplash.position.y, enemySplash.position.z);
                    }
                    break;
        }
	}
}
