using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrunderBehavior : MonoBehaviour {

    Animator anim;
    string notekey;
    bool primed;
    bool activeLongNote;
    public Transform effect;
    List<GameObject> Colliding;

    // Use this for initialization
    void Start () {
        primed = false;
        Colliding = new List<GameObject>();
        switch (gameObject.name) {
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
        if(activeLongNote && Colliding[0] == null) { activeLongNote = false; }
        Colliding.RemoveAll(delegate (GameObject o) { return o == null; });
        if (Input.GetButton(notekey))
        {
            anim.SetBool("Pressed", true);
            if (Colliding.Count != 0 && primed && !activeLongNote)
            {
                if(Colliding[0].name == "NoteLong(Clone)") 
                {
                    Colliding[0].GetComponent<NoteLongBehavior>().stage = 1;
                    activeLongNote = true;
                }
                if (!activeLongNote)
                {
                    Destroy(Colliding[0]);
                    Instantiate(effect, GetComponent<Transform>().position, effect.rotation);
                }
            }
            primed = false;
        }
        else
        {
            anim.SetBool("Pressed", false);
            primed = true;
            if (activeLongNote)
            {
                Colliding[0].GetComponent<NoteLongBehavior>().stage = 3;
                Colliding.RemoveAt(0);
                activeLongNote = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            Colliding.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "NoteLong(Clone)")
        {
            if (other.GetComponent<NoteLongBehavior>().stage == 0)
            {
                Colliding.RemoveAt(0);
                other.GetComponent<NoteLongBehavior>().stage = 3;
            }
        }
        else
        {
            Colliding.RemoveAt(0);
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
        }
    }

}
