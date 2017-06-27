using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public Dialogue experiment;
    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Return) && !dialogueManager.gameManager.InDialogue)
        {
            dialogueManager.gameManager.Paused = true;
            dialogueManager.gameManager.InDialogue = true;
            dialogueManager.dialogue = experiment;
            dialogueManager.currentLine = 0;
            dialogueManager.currentNode = 0;
            dialogueManager.currentOption = 0;
            dialogueManager.dialogueOption.text = "";
            dialogueManager.entryLine = true;
            dialogueManager.DisplayTextBox();
        }
    }
}
