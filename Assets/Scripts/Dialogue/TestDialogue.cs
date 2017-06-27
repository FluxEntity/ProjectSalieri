using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : Dialogue {

    //Dialogue tester = new Dialogue();

	// Use this for initialization
	void Start () {
        InitializeDialogue();
        gameObject.GetComponent<DialogueHolder>().experiment = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    new void InitializeDialogue()
    {
        DialogueNode node1 = new DialogueNode("This a presentation of Project Salieri's dialogue tree.", "This means that the string arrays work.");
        DialogueNode node2 = new DialogueNode("I hope you will find this game to your liking!");
        DialogueNode node3 = new DialogueNode("Alright, now let's test this test!");
        DialogueNode node4 = new DialogueNode("Who put you on the planet?");

        this.AddNode(node1);
        this.AddNode(node2);
        this.AddNode(node3);
        this.AddNode(node4);

        this.AddOption("Yes", node1, node3);
        this.AddOption("No", node1, node4);
    }
}
