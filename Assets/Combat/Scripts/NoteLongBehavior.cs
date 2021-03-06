﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLongBehavior : MonoBehaviour
{
    AudioBehavior audioRef;
    Animator animator;
    public Transform noteTail;
    public float tailLength;
    public bool passed;
    public int stage;

    // Use this for initialization
    void Start()
    {
        audioRef = GameObject.Find("AudioManager").GetComponent<AudioBehavior>();
        noteTail = Instantiate(noteTail, transform.position, noteTail.rotation);
        noteTail.SetParent(transform);
        noteTail.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(noteTail.transform.GetComponent<SpriteRenderer>().size.x, tailLength);
        noteTail.position = new Vector3(noteTail.position.x, noteTail.position.y + tailLength/2 - 0.14f);
        animator = noteTail.gameObject.GetComponent<Animator>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.moddedNoteVelocity, 0);
        stage = 0;
        passed = false;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        switch (stage) {
            case (0):
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.moddedNoteVelocity, 0);
                break;
            case (1):
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                float offset = transform.position.y - (transform.parent.position.y + transform.parent.GetComponent<PianoAttack>().crunderDistance);
                transform.position = new Vector3(transform.position.x, transform.parent.position.y + transform.parent.GetComponent<PianoAttack>().crunderDistance);
                tailLength = Mathf.Max(0, tailLength - audioRef.moddedNoteVelocity * Time.deltaTime + offset);
                noteTail.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(noteTail.gameObject.GetComponent<SpriteRenderer>().size.x, tailLength);
                noteTail.position = new Vector3(noteTail.position.x, transform.position.y + tailLength / 2 - 0.14f);
                animator.SetBool("Glowing", true);
                stage = 2;
                break;
            case (2):
                tailLength = Mathf.Max(0, tailLength - audioRef.moddedNoteVelocity * Time.deltaTime);
                noteTail.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(noteTail.gameObject.GetComponent<SpriteRenderer>().size.x, tailLength);
                noteTail.position = new Vector3(noteTail.position.x, transform.position.y + tailLength / 2 - 0.14f);
                if(tailLength < audioRef.moddedNoteVelocity/6)
                {
                    passed = true;
                }   
                if(tailLength == 0)
                {
                    stage = 3;
                }
                break;
            case (3):
                if (passed)
                {
                    Destroy(gameObject);
                }
                else
                {
                    animator.SetBool("Glowing", false);
                    GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
                    noteTail.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
                    GetComponent<Rigidbody2D>().velocity = new Vector3(0, -audioRef.moddedNoteVelocity, 0);
                }
                break;
        }
    }
}
