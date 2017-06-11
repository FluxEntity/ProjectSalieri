using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehavior : MonoBehaviour {
    public Transform burst;
    public bool primed;
    AudioBehavior audioRef;

	// Use this for initialization
	void Start () {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.noteVelocity, 0);
        primed = false;
	}
	
	//Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.noteVelocity, 0);
    }

  /*  void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "PianoAttack(Clone)")
        {
            if ((!Input.GetButton("Note1")) && gameObject.name == "Note1(Clone)")
            {
                primed = true;
            }
            if ((!Input.GetButton("Note2")) && gameObject.name == "Note2(Clone)")
            {
                primed = true;
            }
            if ((!Input.GetButton("Note3")) && gameObject.name == "Note3(Clone)")
            {
                primed = true;
            }
            if ((!Input.GetButton("Note4")) && gameObject.name == "Note4(Clone)")
            {
                primed = true;
            }
            if ((!Input.GetButton("Note5")) && gameObject.name == "Note5(Clone)")
            {
                primed = true;
            }
            if ((!Input.GetButton("Note6")) && gameObject.name == "Note6(Clone)")
            {
                primed = true;
            }


            if ((Input.GetButton("Note1")) && gameObject.name == "Note1(Clone)" && primed)
            {
                Destroy(gameObject);
            }
            if ((Input.GetButton("Note2")) && gameObject.name == "Note2(Clone)" && primed)
            {
                Destroy(gameObject);
            }
            if ((Input.GetButton("Note3")) && gameObject.name == "Note3(Clone)" && primed)
            {
                Destroy(gameObject);
            }
            if ((Input.GetButton("Note4")) && gameObject.name == "Note4(Clone)" && primed)
            {
                Destroy(gameObject);
            }
            if ((Input.GetButton("Note5")) && gameObject.name == "Note5(Clone)" && primed)
            {
                Destroy(gameObject);
            }
            if ((Input.GetButton("Note6")) && gameObject.name == "Note6(Clone)" && primed)
            {
                Destroy(gameObject);
            }
        }
    }*/
}
