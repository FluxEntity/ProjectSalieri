using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

    public List<DialogueNode> dialogueTree;

    public void AddNode(DialogueNode node)
    {
        // if the node is null, then it's an ExitNode and skip adding it.
        if (node == null) { return; }

        // Add the node to the dialogue list of nodes, assigning an ID
        dialogueTree.Add(node);
        node.nodeID = dialogueTree.IndexOf(node);
    }

    public void AddOption(string text, DialogueNode node, DialogueNode dest)
    {
        if (!dialogueTree.Contains(dest)) { AddNode(dest); }
        if (!dialogueTree.Contains(node)) { AddNode(node); }

        DialogueOption option;

        // If the destination is an ExitNode, set the index to -1
        if (dest == null) { option = new DialogueOption(text, -1); }
        else { option = new DialogueOption(text, dest.nodeID); }

        node.options.Add(option);
    }

    public Dialogue()
    {
        dialogueTree = new List<DialogueNode>();
    }

    public void InitializeDialogue()
    {
        // Abstract method located in child dialogue
    }
}
