using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrunderBehavior : MonoBehaviour {

    Animator anim;
    string notekey;
    string objectname;
    bool primed;
    List<GameObject> Colliding;

    // Use this for initialization
    void Start () {
        primed = false;
        Colliding = new List<GameObject>();
        objectname = gameObject.name;
        switch (objectname) {
            case ("Crunder1(Clone)"):
                    notekey = "Note1";
                    break;
            case ("Crunder2(Clone)"):
                notekey = "Note2";
                break;
            case ("Crunder3(Clone)"):
                notekey = "Note3";
                break;
            case ("Crunder4(Clone)"):
                notekey = "Note4";
                break;
            case ("Crunder5(Clone)"):
                notekey = "Note5";
                break;
            case ("Crunder6(Clone)"):
                notekey = "Note6";
                break;
        }
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(notekey))
        {
            anim.SetBool("Pressed", true);
        }
        else
        {
            anim.SetBool("Pressed", false);
        }
        if(Colliding.Count != 0)
        {
            if (Input.GetButton(notekey))
            {
                if (primed)
                {
                    Destroy(Colliding[0]);
                    Colliding.RemoveAll(delegate (GameObject o) { return o == null; });
                    primed = false;
                }
            }
            else
            {
                primed = true;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            print("HITTIME: " + GameObject.Find("AudioManager").GetComponent<AudioBehavior>().trackTime);
            Colliding.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Colliding.RemoveAt(0);
        other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void miss()
    {

    }
    
    void hit()
    {

    }

}
