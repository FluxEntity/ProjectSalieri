using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public TextAsset dialogue;
    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (true) {
                dialogueManager.textFile = dialogue;
                dialogueManager.AcceptText();
                dialogueManager.DisplayTextBox();
            }
        }
    }
}
