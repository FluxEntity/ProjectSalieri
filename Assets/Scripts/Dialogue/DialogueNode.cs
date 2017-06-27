using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode {

    public int nodeID = -1;
    public string text;
    public List<string> conversation;
    public List<DialogueOption> options;

    public DialogueNode()
    {
        options = new List<DialogueOption>();
    }

    public DialogueNode(string message)
    {
        options = new List<DialogueOption>();
        conversation = new List<string>();
        conversation.Add(message);
    }

    public DialogueNode(params string[] message)
    {
        options = new List<DialogueOption>();
        this.conversation = new List<string>();
        for (int i = 0; i < message.Length; i++)
        {
            this.conversation.Add(message[i]);
        }
    }

}
