using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour {

    Dialogue tester = new Dialogue();

	// Use this for initialization
	void Start () {
        InitializeDialogue();
        GetComponent<DialogueHolder>().experiment = tester;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeDialogue()
    {
        DialogueNode node1 = new DialogueNode("This a presentation of Project Salieri's dialogue tree.", "This means that the string arrays work.");
        DialogueNode node2 = new DialogueNode("I hope you will find this game to your liking!");
        DialogueNode node3 = new DialogueNode("Alright, now let's test this test!");
        DialogueNode node4 = new DialogueNode("Who put you on the planet?");

        tester.AddNode(node1);
        tester.AddNode(node2);
        tester.AddNode(node3);
        tester.AddNode(node4);

        tester.AddOption("Yes", node1, node3);
        tester.AddOption("No", node1, node4);
    }
}
