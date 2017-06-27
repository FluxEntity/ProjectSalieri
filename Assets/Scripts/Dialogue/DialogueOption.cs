using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption {

    public string text;
    public int destNodeID;

    public DialogueOption()
    {

    }

    public DialogueOption(string message, int dest)
    {
        this.text = message;
        this.destNodeID = dest;
    }

}
