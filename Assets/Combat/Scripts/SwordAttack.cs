using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordAttack : MonoBehaviour {

    CombatStateMachine CSM;
    public Transform spinner;
    public Transform circle;
    public Transform target;
    public Transform slash;
    public float damageFactor;
    AudioBehavior audioRef;
    float totalRotation;
    bool primed;
    float waitTime;

    enum State
    {
        ACTIVE,
        HIT,
        MISSED,
        DAMAGEDELAY,
        SENDDAMAGE,
        DONE,
        DESTROYDELAY,
    }

    State currentState;

	// Use this for initialization
	void Start () {
        CSM = GameObject.Find("BattleManager").GetComponent<CombatStateMachine>();
        CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 4);
        totalRotation = 0;
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        target.Rotate(Vector3.forward * Random.Range(0, 7) * 22.5f);
        primed = false;
        waitTime = 0;
        currentState = State.ACTIVE;
    }
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case (State.ACTIVE):
                spinner.Rotate(Vector3.forward * Time.deltaTime * (360 / (audioRef.SPB * audioRef.BPB/audioRef.source.pitch)));
                totalRotation += Time.deltaTime * (360 / (audioRef.SPB * audioRef.BPB/audioRef.source.pitch));

                if (!Input.GetButton("Affirm"))
                {
                    primed = true;
                }

                if (Input.GetButton("Affirm") && primed)
                {
                    currentState = State.HIT;
                    primed = false;
                }
                else if (totalRotation > 720)
                {
                    currentState = State.MISSED;
                }
                circle.GetComponent<SpriteRenderer>().color = new Color(Mathf.Min(circle.GetComponent<SpriteRenderer>().color.r + Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2 / audioRef.source.pitch), 1), Mathf.Max(circle.GetComponent<SpriteRenderer>().color.g - Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2 / audioRef.source.pitch), 0), 0, 0.65f);
                target.GetComponent<SpriteRenderer>().color = new Color(Mathf.Min(target.GetComponent<SpriteRenderer>().color.r + Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2 / audioRef.source.pitch), 1), Mathf.Max(target.GetComponent<SpriteRenderer>().color.g - Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2 / audioRef.source.pitch), 0), 0, 0.65f);
                circle.localScale = new Vector3(Mathf.Max(circle.localScale.x - Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2/audioRef.source.pitch), 0), Mathf.Max(circle.localScale.y - Time.deltaTime / (audioRef.SPB * audioRef.BPB * 2 / audioRef.source.pitch), 0), 1);
                break;

            case (State.HIT):
                float correctedAngle = spinner.eulerAngles.z % 180;
                float angleDif = Mathf.Min(Mathf.Abs(correctedAngle - target.eulerAngles.z), 180 - Mathf.Abs(correctedAngle - target.eulerAngles.z));
                //print("Angle Difference: " + angleDif);
                //print("Spinner Angle: " + spinner.eulerAngles.z);
                //print("Target Angle: " + target.eulerAngles.z);
                damageFactor = 1 - (angleDif / 100);
                Instantiate(slash, spinner.position, spinner.rotation);
                GetComponent<AudioSource>().Play();
                waitTime = Time.time + audioRef.SPB;
                currentState = State.DAMAGEDELAY;
                Destroy(spinner.gameObject);
                Destroy(circle.gameObject);
                Destroy(target.gameObject);
                CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 3);
                break;

            case (State.MISSED):
                damageFactor = 0;
                CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 1);
                waitTime = Time.time + audioRef.SPB*4;
                Destroy(spinner.gameObject);
                Destroy(circle.gameObject);
                Destroy(target.gameObject);
                currentState = State.DESTROYDELAY;
                break;

            case (State.DAMAGEDELAY):
                if(Time.time >= waitTime)
                {
                    currentState = State.SENDDAMAGE;
                }
                break;

            case (State.SENDDAMAGE):
                CSM.selectedEnemy.TakeDamage((int)(damageFactor * 20));
                CSM.GetComponent<AudioSource>().Play();
                waitTime = Time.time + audioRef.SPB*2;
                currentState = State.DESTROYDELAY;
                break;

            case (State.DONE):
                Destroy(gameObject);
                break;

            case (State.DESTROYDELAY):
                if(Time.time > waitTime)
                {
                    CSM.graphicPanel.GetComponent<Animator>().SetInteger("graphic", 0);
                    Destroy(gameObject);
                }
                break;
        }
    }
}
